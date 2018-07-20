import { TreeItem } from 'ngx-treeview';

export class TaxComponent {
    public TaxComponentId: number;
    public Title: string;
    public LevelId:number;
    public ParentId :number;
    public SortId :number;
    public IsReadOnly:boolean;
    public IsActive: boolean;

    public hasChildren: boolean;

    public ChildNodes: TaxComponent[];

    public Amount: number;
}

export class TaxComponentTreeItem implements TreeItem {
    public text: string;
    public value: any;
    public disabled?: boolean;
    public checked?: boolean;
    public collapsed?: boolean;
    public children?: TreeItem[];
}