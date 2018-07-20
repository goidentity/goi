export class ProcessSalary {
    public ProcessSalaryId: number;
    public ProcessDate: number;
    public ReleasedDate: number;
    public IsOnHold: number;
    public LocationId: number;
    public EmployeeId: number;
    public EmployeeLevelId: number;
    public ApprisalYearId: number;
    public PayCycleId: number;
    public PayCalculationModeId: number;
    public StartDate: number;
    public EndDate: number;
    public Gross: number;
    public Net: number;
}

export class vProcessSalary {
    public EmployeeId: number;
    public PayCycleId: number;
    public ApprisalYearId: number;
    public EmployeeNumber: string;
    public EmployeeLevelId: number;
    public EmployeeName: string;
    public EmployeeLevel: string;
    public CalendarDays: number;
    public WorkingDays: number;
    public Leaves: number;
    public SalaryHeaderId: number;
    public Net: number;
    public Gross: number;
    public SalaryDetails: Array<vSalaryDetails>;
}

export class vSalaryDetails {
    public SalaryHeaderId: number;
    public SalaryComponentId: number;
    public SalaryComponent: string;
    public IsAddition: boolean;
    public FreeEntry: number;
    public Amount: number;
}