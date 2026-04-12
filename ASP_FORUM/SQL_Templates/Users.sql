CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,

    -- Identidad
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL,

    -- Seguridad
    PasswordHash NVARCHAR(255) NOT NULL,

    -- Estado cuenta
    IsActive BIT NOT NULL DEFAULT 1,
    IsBanned BIT NOT NULL DEFAULT 0,
    BannedReason NVARCHAR(500) NULL,
    BannedAt DATETIME2 NULL,
    BannedById INT NULL,

    -- Auditoría
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    LastLoginAt DATETIME2 NULL,

    -- Stats
    ThreadCount INT NOT NULL DEFAULT 0,
    PostCount INT NOT NULL DEFAULT 0,

    -- Personalización
    Role NVARCHAR(20) NOT NULL DEFAULT 'User',
    AvatarUrl NVARCHAR(500) NULL,
    Bio NVARCHAR(1000) NULL,

    -- FK autoreferencia (baneo por otro usuario)
    CONSTRAINT FK_Users_BannedBy
        FOREIGN KEY (BannedById) REFERENCES Users(Id)
);

-- Evitar usuarios duplicados
CREATE UNIQUE INDEX IX_Users_Username ON Users(Username);
CREATE UNIQUE INDEX IX_Users_Email ON Users(Email);
