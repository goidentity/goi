export class TaxDeclaration {
    public TaxDeclarationId:number;
    public TaxComponentId:number;
    public ApprisalYearId: number;
    public EmployeeId: number;
    public Amount:number; 
}

export class vTaxDeclaration {
    public TaxComponentId: number;
    public Title: string;
    public ParentId: number;
    public LevelId: number;
    public TaxDeclarationId: number;
    public ApprisalYearId: number;
    public EmployeeId: number;
    public Amount: number;
}