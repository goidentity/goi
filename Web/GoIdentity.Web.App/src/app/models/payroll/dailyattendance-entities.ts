export class DailyAttendance {
    public DailyAttendanceId: number;
    public EmployeeId: number;
    public AttendanceDate: Date;
    public CountValue: number;
    public IsFirstHalfPresent: boolean;
    public IsSecondHalfPresent: boolean;
    public AttendanceSourceLookupId: number;
    public FullName: boolean;
    public EmployeeNumber: number;
    public StartTime: Date;
    public EndTime: Date;
    public TotalTime: TimeRanges;
    public OTHours: TimeRanges;
    public PayCycleId: number;
    public PayCycleAttendanceId: number;
    public EmployeeLevelId: number;
    public WorkingDays: number;
    public Attended: number;
}
