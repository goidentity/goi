export class TaxCalculation {
    public Id: number 
    public TaxCalculationComponent: TaxSalaryComponent[]
}
export class TaxSalaryComponent {
    public SalaryDetailId: number
    public SalaryComponentId: number
    public Title: string
    public DefaultAmount: number
    public IsAddition: boolean
    public Amount : number
}
//export class PayslipSallaryDetail {
//    public ProcessSalaryDetailId: number
//    public Title: string
//    public Amount: number
//    public DefaultAmount: number
//    public IsAddition: number
//}
