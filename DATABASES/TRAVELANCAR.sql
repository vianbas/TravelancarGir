-- Script Date: 5/23/2016 7:52 PM  - ErikEJ.SqlCeScripting version 3.5.2.58
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [webpages_Roles] (
  [RoleId] INTEGER NOT NULL
, [RoleName] nvarchar(256) NOT NULL
, CONSTRAINT [PK__webpages__8AFACE1A9CFDF729] PRIMARY KEY ([RoleId])
);
CREATE TABLE [webpages_OAuthMembership] (
  [Provider] nvarchar(30) NOT NULL
, [ProviderUserId] nvarchar(100) NOT NULL
, [UserId] int NOT NULL
, CONSTRAINT [PK__webpages__F53FC0ED416AE171] PRIMARY KEY ([Provider],[ProviderUserId])
);
CREATE TABLE [webpages_Membership] (
  [UserId] int NOT NULL
, [CreateDate] datetime NULL
, [ConfirmationToken] nvarchar(128) NULL
, [IsConfirmed] bit DEFAULT 0 NULL
, [LastPasswordFailureDate] datetime NULL
, [PasswordFailuresSinceLastSuccess] int DEFAULT 0 NOT NULL
, [Password] nvarchar(128) NOT NULL
, [PasswordChangedDate] datetime NULL
, [PasswordSalt] nvarchar(128) NOT NULL
, [PasswordVerificationToken] nvarchar(128) NULL
, [PasswordVerificationTokenExpirationDate] datetime NULL
, CONSTRAINT [PK__webpages__1788CC4C6FEFE359] PRIMARY KEY ([UserId])
);
CREATE TABLE [UserProfile] (
  [UserId] INTEGER NOT NULL
, [UserName] ntext NULL
, CONSTRAINT [PK__UserProf__1788CC4CD9AF2BF0] PRIMARY KEY ([UserId])
);
CREATE TABLE [webpages_UsersInRoles] (
  [UserId] int NOT NULL
, [RoleId] int NOT NULL
, CONSTRAINT [PK__webpages__AF2760ADCA2A5AC5] PRIMARY KEY ([UserId],[RoleId])
, FOREIGN KEY ([RoleId]) REFERENCES [webpages_Roles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([UserId]) REFERENCES [UserProfile] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO [webpages_Membership] ([UserId],[CreateDate],[ConfirmationToken],[IsConfirmed],[LastPasswordFailureDate],[PasswordFailuresSinceLastSuccess],[Password],[PasswordChangedDate],[PasswordSalt],[PasswordVerificationToken],[PasswordVerificationTokenExpirationDate]) VALUES (
1,'2016-05-23 03:09:29.663',NULL,1,NULL,0,'APFnaSVYAxns9otkBUaI57eD3YbeL5VRmCVhRnz8L4mgfsZwtEoU++cmhUFsnP2dmA==','2016-05-23 03:09:29.663','',NULL,NULL);
INSERT INTO [webpages_Membership] ([UserId],[CreateDate],[ConfirmationToken],[IsConfirmed],[LastPasswordFailureDate],[PasswordFailuresSinceLastSuccess],[Password],[PasswordChangedDate],[PasswordSalt],[PasswordVerificationToken],[PasswordVerificationTokenExpirationDate]) VALUES (
2,'2016-05-23 09:16:34.400',NULL,1,NULL,0,'AI7Y13n+y7MhloT7z2kRXt8bBeFMopJbF1aOzEV1Pitb64DQBgG6vi0TqHNyjZmnew==','2016-05-23 09:16:34.400','',NULL,NULL);
INSERT INTO [UserProfile] ([UserId],[UserName]) VALUES (
1,'if414013');
INSERT INTO [UserProfile] ([UserId],[UserName]) VALUES (
2,'adit');
CREATE UNIQUE INDEX [UQ__webpages__8A2B6160096CE4E0_webpages_Roles] ON [webpages_Roles] ([RoleName] ASC);
COMMIT;

