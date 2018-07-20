export class AdvanceApproval {
    public  SalaryAdvanceId: number
    public  AdvanceApprovalStatusLookupId: number
    public  Status: string
    public  AdvanceTypeLookupId: number
    public  ApprovalComments: string;
    public  EmployeeId: number; 
    public  EmployeeNumber: string;
    public  FullName :string
    public  Amount : number
    public  NoOfInstallments: number
    public  RepayFromDate: Date
    public  Reason:string
}

export class ConstLeaveApproval {
    static Pending: string = "Pending";
    static InProcess: string = "InProcess";
    static Approved: string = "Approved";   
    static Reject: string = "Reject";
}