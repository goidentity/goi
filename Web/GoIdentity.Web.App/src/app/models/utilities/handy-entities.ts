import { TreeNode } from 'primeng/api';
import { Observable } from 'rxjs'

export class CustomTreeItem implements TreeNode {
    data?: any;
    children?: TreeNode[];
    leaf?: boolean;
    expanded?: boolean=true;
}

export class ItemValue {
    constructor(value: number, title: string) {
        this.Title = title;
        this.Value = value;
    }
    public Title: string;
    public Value: number;
}

export class Item {
    public Text: string;
    public Value: string;
    public Value2: string;
}

export class GlobalVariables {
    public static PageTitle: string;
}

export class KeyFields {
    public static readonly CUST_ID = "CUST_ID";
    public static readonly PRODUCT = "PRODUCT";
    public static readonly LOCATION = "LOCATION";
    public static readonly SALES_MAN = "SALES_MAN";
    public static readonly QUANTITY = "QUANTITY";
    public static readonly RATE = "RATE";
    public static readonly AMOUNT = "AMOUNT";
    public static readonly DOC_NO = "DOC_NO";
    public static readonly BASE_DOC_NO = "BASE_DOC_NO";
    public static readonly DOC_DATE = "DOC_DATE";
    public static readonly DUE_DATE = "DUE_DATE";
    public static readonly UOM = "UOM";
    public static readonly BATCH = "BATCH";
    public static readonly EXP_DATE = "EXP_DATE";
    public static readonly MFG_DATE = "MFG_DATE";
    public static readonly CURRENCY = "CURRENCY";
    public static readonly EXCHANGE_RATE = "EXCHANGE_RATE";
    public static readonly USER_ID = "USER_ID";
    public static readonly NEXT_FOLLOWUP_DATE = "NEXT_FOLLOWUP_DATE";
    public static readonly CONTRA_LOCATION = "CONTRA_LOCATION";
    public static readonly ACC_GROUP = "ACC_GROUP";
    public static readonly ACC_ID = "ACC_ID";
    public static readonly NARRATION = "NARRATION";
    public static readonly LINE_NARRATION = "LINE_NARRATION";
    public static readonly LINE_ACC_ID = "LINE_ACC_ID";
    public static readonly VOUCHER_TOTAL = "VOUCHER_TOTAL";
    public static readonly DEPARTMENT = "DEPARTMENT";
    public static readonly PROJECT = "PROJECT";
    public static readonly BRANCH = "BRANCH";
    public static readonly GROSS = "GROSS";
    public static readonly NET = "NET";
}