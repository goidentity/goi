export class AccessControl {
    public AccessControlId: number;
    public NavigationId: number;
    public RoleId: number;
    public IsView: boolean;
    public IsInsert: boolean;
    public IsEdit: boolean;
    public IsDelete: boolean;
    public IsPrint: boolean;
}

export class vAccessControl extends AccessControl {
    public OrganizationId: number;
    public Title: string;    
    public LevelId: number;
    public ParentNavigationId?: number;    
    public IsReadOnly: boolean;
}