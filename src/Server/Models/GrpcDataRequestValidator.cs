using System.Globalization;
using FluentValidation;

namespace Server.Models;

public class GrpcDataRequestValidator : AbstractValidator<ConfigurationRequest>
{
    public GrpcDataRequestValidator()
    {
        RuleFor(r => r.PacketTimestamp);
        
        RuleFor(r => r.PacketSeqNumber)
            .NotEmpty();
        
        RuleFor(r => r.NRecords)
            .Must(n => n > 0)
            .NotEmpty();

        RuleFor(r => r.PacketData)
            .Must(p => p.Count > 1)
            .NotEmpty();

        RuleForEach(r => r.PacketData)
            .Must(d => IsDecimalValid(d.Decimal1) 
                       && IsDecimalValid(d.Decimal2)
                       && IsDecimalValid(d.Decimal3)
                       && IsDecimalValid(d.Decimal4));
    }
    
    private bool IsDecimalValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;

        value = value.Replace(',', '.');

        return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
    }
}