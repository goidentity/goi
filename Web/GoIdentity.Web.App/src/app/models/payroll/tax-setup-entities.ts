export class vTaxSetup {
    public TaxSetupId: number;
    public ApprisalYearId: number
    public GenderLookupId: number;
    public Gender: string;
    public AgeFrom: number;
    public AgeTo: number;
    public FromAmount: number;
    public ToAmount: number;
    public TaxPercentage: number;
}

export class TaxSetup {
    public TaxSetupId: number
    public ApprisalYearId: number
    public GenderLookupId: number
    public AgeFrom: number
    public AgeTo: number
    public FromAmount: number
    public ToAmount: number
    public TaxPercentage: number
}