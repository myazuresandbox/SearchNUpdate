using System;

using System.Collections.Generic;

public class Consent : IEqualityComparer<Consent>
{
    public string? consentType { get; set; }
    public string? consentReceiver { get; set; }
    public string? consentCategory { get; set; }
    public string? consentStatus { get; set; }
    public DateTime LastUpdate { get; set; }
                
    public bool Equals(Consent? first, Consent? second)
    {
        
        return (first?.consentCategory == second?.consentCategory 
        && first?.consentReceiver == second?.consentReceiver
        && first?.consentType == second?.consentType
        && first?.consentStatus == second?.consentStatus
        );
    }

    public int GetHashCode(Consent obj)
    {
        return base.GetHashCode();
    }
}