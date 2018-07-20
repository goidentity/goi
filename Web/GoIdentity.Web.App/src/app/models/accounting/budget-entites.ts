export class BudgetExtended {
    public AccountHeadId: number;
    public Title: string;
    public Month01: number;
    public Month02: number;
    public Month03: number;
    public Month04: number;
    public Month05: number;
    public Month06: number;
    public Month07: number;
    public Month08: number;
    public Month09: number;
    public Month10: number;
    public Month11: number;
    public Month12: number
}
export class Budget {
    index: number;
    AccountHeadId: number;
    Periods: number;
    Month: Date;
    SplitAmount: number;
    AmountDiv: number;
    AmountPlus: number;
    AmountPercent: number;
    Amount: number;
}
export interface TypeofAmountList {
    text: string,
    value: number
}
export enum BudgetColumnTitles {
    Jan,
    Feb,
    Mar,
    Apr,
    May,
    Jun,
    Jul,
    Aug,
    Sep,
    Oct,
    Nov,
    Dec
}

export class vBudget {
    BudgetId: number;
    AccountHeadId: number;
    Periods: number;
    MonthYear: Date;
    Amount: number;
}


