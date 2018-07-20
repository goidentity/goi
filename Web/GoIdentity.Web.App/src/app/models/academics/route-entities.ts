import { TreeItem } from 'ngx-treeview';

export class Route {
    public RouteId: number;
    public Title: string;
    public VehicleId: number;
    public LocationId: number;
    public AcademicYearId: number;
    public IsGroup: boolean;
    public ParentId: number;
   
    public IsActive: boolean;

    public hasChildren: boolean;

    public ChildNodes: Route[];

}


export class RouteTreeItem implements TreeItem {
    public text: string;
    public value: any;
    public disabled?: boolean;
    public checked?: boolean;
    public collapsed?: boolean;
    public children?: TreeItem[];
}