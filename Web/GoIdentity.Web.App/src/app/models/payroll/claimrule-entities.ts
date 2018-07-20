export class ClaimRule {
    public ClaimRuleId:number;
    public ClaimTypeId: number;
    public ApprisalYearId: number;
    public EmployeeLevelId: number;
    public Limit: number;
    public FrequencyLookupId: number;
    public IsTaxBenefit: boolean;
    public MaxTaxBenefitLimit: number;
}

export class vClaimRule {
    public ClaimRuleId: number;
    public Title: string;
    public EmployeeLevelId: number;
    public ClaimTypeId: number;
    public ClaimTitle: string;
    public ApprisalYearId: number;
    public FromDate: Date;
    public Limit: number;
    public FrequencyLookupId: number;
    public Value: string;
    public IsTaxBenefit: boolean;
    public MaxTaxBenefitLimit: number;
}