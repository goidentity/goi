
export class vMapUserRole {
    public RoleId: number;
    public Title: string;
    public DefaultPage: number;
    public OrganizationId: number;
    public IsActive: boolean;
    public IsAdmin: boolean;
    public IsDefault: boolean;
    public MapUserRoleId: number;
    public UserId: number;
    public IsCheck: boolean;
}

export class Role {
    public RoleId: number;
    public Title: string;
    public OrganizationId: number;
    public DefaultPage: number;
    public IsActive: boolean = true;
    public IsAdmin: boolean = true;
    public IsDefault: boolean = true;

}

export class MapUserRole {
    public MapUserRoleId: number;
    public UserId: number;
    public RoleId: number;
}