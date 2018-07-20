import { TreeItem } from 'ngx-treeview';


//export class FeeComponent {
//    public FeeComponentId: number;
//    public Title: string;
//    public Code: string;
//    public IsGroup: boolean;
//    public ParentId: number;
//    public IsTransport: boolean;
//    public IsActive: boolean;
//}

export class FeeComponent {
    public FeeComponentId: number;
    public Title: string;
    public Code: string;
    public IsGroup: boolean;
    public ParentId: number;
    public IsTransport: boolean
    public IsActive: boolean;

    public hasChildren: boolean;

    public ChildNodes: FeeComponent[];

}



export class FeeComponentTreeItem implements TreeItem {
    public text: string;
    public value: any;
    public disabled?: boolean;
    public checked?: boolean;
    public collapsed?: boolean;
    public children?: TreeItem[];
}



