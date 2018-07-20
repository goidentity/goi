import { SalaryDetail } from '../oneemployee/salarydetail-entities';

export class SalaryHeader {
    public SalaryHeaderId: number;
    public FromDate: Date;
    public ApprisalYearId: number;
    public EmployeeId: number;

    public Additions: number;
    public Deductions: number;
    public Net: number;

    public Items: Array<SalaryDetail>;
}