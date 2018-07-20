export class Settings {
    public SettingsId: number;
    public OrganizationId: number;
    public FinancialYearId: number;
    public ApprisalYearId: number;
    public AcademicYearId: number;
    public SettingsTypeId: number;
    public SettingValue: number;
    public Password: string;
}
export class vSettings {
    public SettingsId: number;
    public FinancialYearId: number;
    public ApprisalYearId: number;
    public AcademicYearId: number;
    public SettingsTypeId: number;
    public PayrollFrequencyLookupId: number
    public PaycalculationModeLookupId: number
    public ClaimRestrictModeLookupId: number
    public IsOTEnabled: boolean
    public IsSGCPFEnabled: boolean
    public SettingValue: string;
    public Password: string;

    public OrganizationId: number;
    public MaintainBillWiseAccountingLookupId: number
    public CheckNegativeCashBalanceLookupId: number
    public CheckCreditLimitsLookupId: number
    public CheckBudgetsLookupId: number
    public ShowPDCLookupId: number
    public MaintainInForCurrency: boolean
    public LineNarrationInVouchers: boolean
    public CheckNegativeStockLookupId: number
    public RealisedGainAccountHead: number
    public RealisedLossAccountHead: number
    public Autopostforex: boolean
}

export class SettingType {
    public SettingsTypeId: number;
    public Title: string;
    public Category: string;
    public DefaultValue: number;
}

export class SettingTypes {
    public SettingsTypeId: number;
    public SettingValue: number;
    public Value: string;
}

export class SettingsDetails {
    public RowNumber: number;
    public SettingsTypeId: number;
    public Title: string;
    public Category: string;
    public DefaultValue: number;
    public IsChecked: boolean;
    public SettingsId: number;
    public OrganizationId: number;
    public FinancialYearId: number;
    public ApprisalYearId: number;
    public AcademicYearId: number;
    public SettingValue: number;
    public Password: string;
}
