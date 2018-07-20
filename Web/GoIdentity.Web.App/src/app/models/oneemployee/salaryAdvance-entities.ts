export class SalaryAdvance {
    public  SalaryAdvanceId : number
    public  EmployeeId: number
    public  AdvanceTypeLookupId: number
    public  AdvanceDate:Date
    public  Amount:number
    public  AdvanceApprovalStatusLookupId:number
    public  Reason: string
    public  ApprovedBy: number
    public  ApprovalComments: string
    public  RepayFromDate:Date
    public  NoOfInstallments:number
}
export class vSalaryAdvance {
    public  SalaryAdvanceId: number
    public  AdvanceApprovalStatusLookupId: number
    public  ApprovalComments: string;
    public  EmployeeId: number
    public  EmployeeNumber: string
    public  FullName: string
    public  AdvanceTypeLookupId: number    
    public  AdvanceDate:Date
    public  Amount  :number
    public  Status :string
    public  NoOfInstallments :number
    public  RepayFromDate: Date
    public  Remaining: number
    public  Reason: string
}
 