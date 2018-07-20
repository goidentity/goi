export class LeaveApproval {
    public ApplyLeaveId: number
    public ApprisalYearId: number
    public EmployeeId: number 
    public LeaveApprovalStatusId: number
    public ApproverComments: string;
    public FullName: string;
    public LeaveTypeId: number 
    public Title: string 
    public FromDate: Date;
    public ToDate: Date;
    public NoOfDays: number;
    public ReasonForLeave: string;
    public Status: string
}



export class vLeaveApproval {
    public ApplyLeaveId: number
    public ApprisalYearId: number
    public EmployeeId: number
    public LeaveApprovalStatusId: number
    public ApproverComments: string;
    public FullName: string;
    public LeaveTypeId: number
    public Title: string
    public FromDate: Date;
    public ToDate: Date;
    public NoOfDays: number;
    public ReasonForLeave: string;
    public Status: string
}

//export class ConstLeaveApproval {
//    static Pending: string = "Pending";
//    static Approved: string = "Approved";
//    static OnHold: string = "OnHold";
//    static Reject: string = "Reject";
//}

//export class EmployeeLeaveApproval {
//    public EmployeeId: number
//    public SupervisorEmployeeId: number
//    public FullName: string
//}