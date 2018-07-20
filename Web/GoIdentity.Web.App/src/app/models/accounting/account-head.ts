import { TreeItem } from 'ngx-treeview';

export class AccountHead {

    public Id: number;
    public AccountHeadId: number;
    public Title: string;
    public Code: string;
    public IsGroup: boolean;
    public IsReadOnly: boolean;
    public AccountTypeId: number;
    public ParentId: number;
    public Description: string;
    public CurrencyId?: number;
    public IsActive: boolean;
    public JsonFeed: string;

    public hasChildren: boolean;

    public ChildNodes: AccountHead[];
}

export class AccountHeadTreeItem implements TreeItem {
    public text: string;
    public value: any;
    public disabled?: boolean;
    public checked?: boolean;
    public collapsed?: boolean;
    public children?: TreeItem[];
}

export class AccountHeadDetails {
    public AccountHeadId: number
    public AccountName: string
    public DebitAmount: number
    public CreditAmount: number
    public OpeningDr: number
    public OpeningCr: number
    public ClosingDr: number
    public ClosingCr: number
}                                                 
