export class ApplyLeave {
    public ApplyLeaveId: number
    public LeaveTypeId: number
    public ApprisalYearId: number  
    public EmployeeId: number
    public FromDate: Date
    public FromDateIsHalf: boolean
    public ToDate: Date
    public ToDateIsHalf: boolean
    public LeaveApprovalStatusId: number
    public ReasonForLeave: string
    public ApproverComments: string
    public EmergencyContact: string
    public Title: string
    public NoOfDays: number
}

export class LeaveBanks{
    public  ApprisalYearId: number
    public EmployeeId: number
    public EmployeeLevelId: number
    public  LeaveTypeId   :number
    public  Title:string
    public  CarryForwardLeaves:number
    public  EarnedLeaves: number
    public  Availed: number
    public  Balance: number
    public  pending: number
}
