using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Models;

namespace Server.Services;

public class ReaderConfigurationService : ReaderConfiguration.ReaderConfigurationBase
{
    private readonly ILogger<ReaderConfigurationService> _logger;
    private ApplicationDbContext _dbContext;    

    public ReaderConfigurationService(
        ILogger<ReaderConfigurationService> logger, 
        ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public override async Task<ResultReply> ReadConfiguration(
        ConfigurationRequest request,
        ServerCallContext context)
    {
        var validationResult = await new GrpcDataRequestValidator().ValidateAsync(request);
        if (validationResult.IsValid == false)
        {
            var error = new Error
            {
                Message = "Request had the wrong format",
                Code = "invalid.request"
            };
            
            _logger.LogError(error.Message);
            
            return new ResultReply
            {
                Error = error,
                IsSuccess = false
            };
        }

        var grpcDataList = new List<GrpcData>();
        for (int i = 0; i < request.PacketData.Count; i++)
        {
            var grpcData = new GrpcData(
                request.PacketSeqNumber, 
                i + 1,
                request.PacketTimestamp.ToDateTime(),
                request.PacketData[i].Decimal1,
                request.PacketData[i].Decimal2,
                request.PacketData[i].Decimal3,
                request.PacketData[i].Decimal4,
                request.PacketData[i].Timestamp.ToDateTime());

            grpcDataList.Add(grpcData);
        }

        return await Save(grpcDataList);
    }

    private async Task<ResultReply> Save(List<GrpcData> grpcDataList)
    {
        try
        {
            await _dbContext.GrpcData.AddRangeAsync(grpcDataList);
            await _dbContext.SaveChangesAsync();
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogError(ex, "Operation has been cancelled");

            var error = new Error
            {
                Message = "Operation has been cancelled",
                Code = "operation.cancelled"
            };

            return new ResultReply
            {
                Error = error,
                IsSuccess = false
            };
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error occurred while saving configuration to database");

            var error = new Error
            {
                Message = "Error occurred while saving configuration to database",
                Code = "database.error"
            };

            return new ResultReply
            {
                Error = error,
                IsSuccess = false
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error");
        }
        
        _logger.LogInformation("The configuration was added successfully");
        
        return new ResultReply
        {
            Error = null,
            IsSuccess = true
        };
    }
}