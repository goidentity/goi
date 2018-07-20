import { TreeItem } from 'ngx-treeview';
import { ArAp, vArApSummary, ApApDialogData } from './arap';


export class ConstVoucherTypes {
    static Payments: number = 1;
    static Receipts: number = 2;
    static Sales: number = 3;
    static Purchases: number = 4;
    static Journal: number = 5;
    static DebitNote: number = 6;
    static CreditNote: number = 7;
    static OpeningBalance: number = 8;
    static PDCPayments: number = 9;
    static PDCReceipts: number = 10;
}

export class ConstAccountTypes {
    static Fixed: number = 1;
    static Cash: number = 2;
    static Bank: number = 3;
    static Customer: number = 4;
    static Capital: number = 5;
    static Sales: number = 6;
    static Purchases: number = 7;
    static Expenses: number = 8;
    static OtherIncome: number = 9;
    static AccountsPayable: number = 10;
    static AccountsReceivable: number = 11;
    static Asset: number = 12;
    static CostOfSales: number = 13;
    static Equity: number = 14;
    static Expense: number = 15;
    static FixedAsset: number = 16;
    static Income: number = 17;
    static Liability: number = 18;
    static OtherAsset: number = 19;
    static OtherLiability: number = 20;
}


export class VoucherType {
    public VoucherTypeId: number
    public Title: string
    public DefaultAccountHeadId: number
    public AccTypeIds: string
    public DefaultDetailAccountHeadId: number
    public DetailAccTypeIds: string
    public ParentId?: number
    public IsReadOnly: number
    public IsActive: boolean

    public hasChildren: boolean;

    public ChildNodes: VoucherType[];
}

export class VoucherTypeTreeItem implements TreeItem {
    public text: string;
    public value: any;
    public disabled?: boolean;
    public checked?: boolean;
    public collapsed?: boolean;
    public children?: TreeItem[];
}

export class Voucher {
    public VoucherId: number;
    public UniqueId: string;
    public VoucherTypeId: number;
    public VoucherSubTypeId: number;
    
    public VoucherNumber: string;

    public VoucherDate: Date;
    public ChequeNumber: string;
    public Narration: string;

    public ChequeStatusLookupId?: number;
    public ClearanceDate?: Date;

    public ConvertedVoucherId?: number;

    public DataSetId: number;
    public RefTransactionId: number;
    public JsonFeed: string;

    public CreatedBy: number;
    public CreatedDate: Date;
    public ModifiedBy: number;
    public ModifiedDate: Date;

    public HeaderItem: VoucherItem;
    public Items: Array<VoucherItem>;

}

export class VoucherItem {
    public VoucherItemId: number
    public UniqueId: string;
    public VoucherId: number
    public ByTo: string
    public AccountHeadId: number
    public DebitAmount: number
    public CreditAmount: number
    public Amount: number
    public ExchangeDebitAmount: number;
    public ExchangeCreditAmount: number;

    public IsPrimary: boolean
    public LineNarration: string

    public IsNotValid: boolean

    public ArApData: ApApDialogData;

    public validate() {
        var result: boolean = true;
        if (this.ByTo == null) {
            result = false;
        }
        else if (this.AccountHeadId == null) {
            result = false;
        }
        else if (this.ByTo == 'By' && (this.DebitAmount == null || this.DebitAmount == 0)) {
            result = false;
        }
        else if (this.ByTo == 'By' && this.CreditAmount > 0) {
            result = false;
        }
        else if (this.ByTo == 'To' && (this.CreditAmount == null || this.CreditAmount == 0)) {
            result = false;
        }
        else if (this.ByTo == 'To' && this.DebitAmount > 0) {
            result = false;
        }

        this.IsNotValid = result;
    }
}

/* Views */
export class vVoucher {
    public VoucherId: number;
    public VoucherDate: Date;
    public VoucherNumber: string;
    public VoucherTypeId: number;
    public VoucherType: string;
    public VoucherSubType: string;
    public Narration: string;
    public CreditAmount: number;
    public DebitAmount: number;
    public Amount: number;
    public AccountHeadId: number;
    public AccountHead: string;
    public Currency: string;
    public ExchangeRate: number;
    public DataSetId: number;
}

export class vVoucherItem extends VoucherItem {
    public AccountName: number
}

export class Customers {
    public CustomerId: number;
    public Title: string;
    public Code: string;
    public AccountHeadId: number;
    public AccountGroupId: number;
    public CreditLimit: number;
    public CreditDays: number;
}