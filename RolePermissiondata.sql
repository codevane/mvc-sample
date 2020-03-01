
-- Modules

INSERT INTO [dbo].[Modules]([Id],[Name],[Description],[ActiveStatus])
VALUES ('6bc1c3ae-93f5-483d-8c9a-411519f1081d','Admin','Admin', 1 );

INSERT INTO [dbo].[Modules]([Id],[Name],[Description],[ActiveStatus])
VALUES ('44d25a39-16bb-418f-b10b-701d7a3ae591','Employee','Emp ', 1 );

INSERT INTO [dbo].[Modules]([Id],[Name],[Description],[ActiveStatus])
VALUES ('e099f54f-858e-4270-ba42-d97a72a9aab4','Audit','Audit', 1 );

-- Permission names
-- Admin Module
INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'6bc1c3ae-93f5-483d-8c9a-411519f1081d','READ',0);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'6bc1c3ae-93f5-483d-8c9a-411519f1081d','CREATE',1);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'6bc1c3ae-93f5-483d-8c9a-411519f1081d','UPDATE',2);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'6bc1c3ae-93f5-483d-8c9a-411519f1081d','DELETE',3);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'6bc1c3ae-93f5-483d-8c9a-411519f1081d','APPROVE',4);

-- Employee Module
INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'44d25a39-16bb-418f-b10b-701d7a3ae591','READ',0);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'44d25a39-16bb-418f-b10b-701d7a3ae591','CREATE',1);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'44d25a39-16bb-418f-b10b-701d7a3ae591','UPDATE',2);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'44d25a39-16bb-418f-b10b-701d7a3ae591','DELETE',3);

-- Audit Module
INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'e099f54f-858e-4270-ba42-d97a72a9aab4','READ',0);

INSERT INTO [dbo].[ModulePermissions]([Id],[ModuleId],[PermissionName],[Sequence])
VALUES ( NEWID(),'e099f54f-858e-4270-ba42-d97a72a9aab4','DELETE',1);


----- Sample data for showing example

-- Insert Role user 
-- for Admin role
INSERT INTO [RoleUsers] ([Id], [RoleId],[UserId])
VALUES ( NEWID(),'c4dd539f-2fb1-4215-aee2-121d7f563b38','26b84eb9-293c-4e8f-b289-56fc5c483de6');

INSERT INTO [RoleUsers] ([Id], [RoleId],[UserId])
VALUES ( NEWID(),'c4dd539f-2fb1-4215-aee2-121d7f563b38','68c92cec-c7be-422a-8e57-2b69d554f4e6');

-- for Operator
INSERT INTO [RoleUsers] ([Id], [RoleId],[UserId])
VALUES ( NEWID(),'6a371b78-2231-4a42-b633-5a539fbf3063','26b84eb9-293c-4e8f-b289-56fc5c483de6');

INSERT INTO [RoleUsers] ([Id], [RoleId],[UserId])
VALUES ( NEWID(),'6a371b78-2231-4a42-b633-5a539fbf3063','9082f694-1d84-46eb-9661-8dd33b0efc4e');

INSERT INTO [RoleUsers] ([Id], [RoleId],[UserId])
VALUES ( NEWID(),'6a371b78-2231-4a42-b633-5a539fbf3063','78d2b9f5-2463-403d-8f86-a64bb6a38e69');

