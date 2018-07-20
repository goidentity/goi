
export class OTConfig {
    public OTConfigId: number;
    public ApprisalYearId: number;
    public EmployeeLevelId: number;
    public OTHour: string;
    public HolidayHour: string;
    public OTHolidayHour: string;
    public BufferedHours: number;

    public EmployeeLevel: EmployeeLevel;
}

export class EmployeeLevel {
    public EmployeeLevelId: number;
    public Title: string;
    public Code: string;
    public IsActive: boolean;
}