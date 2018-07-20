export class ApplyClaim {
    public ApplyClaimId:number; 
    public EmployeeId:number; 
    public ClaimTypeId:number; 
    public Amount:number; 
    public ClaimApprovalStatusLookupId:number; 
    public BillPath:string; 
    public BillNumber:string; 
    public PaidTo: string;
    public BillDate: Date; 
    public Remarks:string; 
    public ApprovedById:number; 
    public ApprovalComments: string;
    public ApprovedDate: Date; 
    public ProcessedCycleId:number; 
}
export class vApplyClaim {
    public ApplyClaimId: number;
    public EmployeeId: number;
    public ClaimTypeId: number;
    public Amount: number;
    public ClaimApprovalStatusLookupId: number;
    public Value: string;
    public BillPath: string;
    public BillNumber: string;
    public PaidTo: string;
    public BillDate: Date;
    public CreatedDate: Date;
    public Remarks: string; 
    public ApprovedById: number;
    public ApprovalComments: string;
    public ApprovedDate: Date; 
    public ProcessedCycleId: number; 
    public FirstName: string;
    public Title: string;
}
export class ApplyClaimDetails {
    public PayCycleId:number;
    public EmployeeId:number; 
    public ClaimTypeId:number;
    public ApprisalYearId:number;
    public Amount:number;
    public StartDate:Date;
    public EndDate :Date;
}
