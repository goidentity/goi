export class EarnLeaveConfig {
    public EarnLeaveConfigId: number;
    public ApprisalYearId: number;
    public LeaveTypeId: number;
    public EmployeeLevelId: number;
    public FrequencyLookupId: number;
    public IsCarryForward: boolean;
    public MaxLimit: number;
    public NoOfLeaves: number;
}
export class vEarnLeaveConfig {

    public EarnLeaveConfigId: number;
    public FrequencyLookupId: number;
    public IsCarryForward: boolean;
    public MaxLimit: number;
    public NoOfLeaves: number;
    public ApprisalYearId: number;
    public EmployeeLevelId: number;
    public Title: string;
    public LeaveTypeId: number;
    public LeaveType: string;
    public IsWorkingDay: boolean
    public Frequency: string;
}