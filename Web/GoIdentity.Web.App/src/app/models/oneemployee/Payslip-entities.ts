export class Payslip {
    public PayslipSallary: PayslipSallary
    public PayslipSallaryDetails: PayslipSallaryDetail[]
}
export class PayslipSallary {
    public ProcessSalaryId: number
    public EmployeeNumber: string
    public FullName: string
    public DoJ: Date
    public HolidaysWorked: number
    public WorkingDays: number
    public WorkedDays: number
    public OT: number
    public HOT: number
    }
export class PayslipSallaryDetail {

    public ProcessSalaryDetailId: number
    public Title: string
    public Amount: number
    public DefaultAmount: number
    public IsAddition: number
}
