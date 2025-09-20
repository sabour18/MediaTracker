DROP TABLE IF EXISTS FavouriteList;
DROP TABLE IF EXISTS Media;
DROP TABLE IF EXISTS MediaType;
DROP TABLE IF EXISTS Movies;
DROP TABLE IF EXISTS Shows;
DROP TABLE IF EXISTS Reviews;
DROP TABLE IF EXISTS WatchedList;
DROP TABLE IF EXISTS Users;

CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NULL,
	[CreatedAt] [datetime2](7) NULL
);
ALTER TABLE [dbo].[Users] ADD  DEFAULT (sysdatetime()) FOR [CreatedAt];

CREATE TABLE [dbo].[MediaType](
	[TypeId] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[Name] [varchar](20) NOT NULL
);
INSERT INTO [dbo].[MediaType] (TypeId, Name)
VALUES 
  (NEWID(), 'Movie'),
  (NEWID(), 'Game'),
  (NEWID(), 'Show');

CREATE TABLE [dbo].[Media](
    MediaId BIGINT NOT NULL PRIMARY KEY,           -- TMDbMovie.Id
    Title NVARCHAR(255) NOT NULL,                  -- movie title
    OriginalTitle NVARCHAR(255) NULL,
    Overview NVARCHAR(MAX) NULL,
    PosterPath VARCHAR(255) NOT NULL,
    BackdropPath VARCHAR(255) NULL,
    MediaType VARCHAR(50) NULL,
    OriginalLanguage VARCHAR(10) NULL,
    Popularity FLOAT NOT NULL,
    ReleaseDate DATE NULL,
    Video BIT NOT NULL,
    VoteAverage FLOAT NOT NULL,
    VoteCount INT NOT NULL,
    GenreIds NVARCHAR(MAX) NULL,                   -- JSON array of genres
    TypeId UNIQUEIDENTIFIER,             -- foreign key to MediaType
    CONSTRAINT FK_TypeMedia FOREIGN KEY (TypeId)
        REFERENCES [dbo].[MediaType](TypeId)
);




  CREATE TABLE FavouriteList
  (
	FavouritesId uniqueidentifier NOT NULL PRIMARY KEY,
	UserId uniqueidentifier NOT NULL,
	TypeId uniqueidentifier,
	MediaId BIGINT NOT NULL,
	CONSTRAINT FK_UserFavourite FOREIGN KEY (UserId) 
	References Users(UserId),
	CONSTRAINT FK_TypeFavourite FOREIGN KEY (TypeId) 
	References MediaType(TypeId),
	CONSTRAINT FK_MediaFavourite FOREIGN KEY (MediaId) 
	References Media(MediaId) 
);
