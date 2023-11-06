CREATE TABLE [dbo].[AdminTable] (
    [Admin_Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR (50) NOT NULL,
    [Password]    NVARCHAR (20) NOT NULL,
    [Email]   NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Admin_Id] ASC)
);

CREATE TABLE [dbo].[MemberTable] (
    [Member_Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR (50) NOT NULL,
    [Password]    NVARCHAR (20) NOT NULL,
    [FirstName]   NVARCHAR (50) NOT NULL,
    [LastName]    NVARCHAR (50) NULL,
    [Country]     NVARCHAR (50) NOT NULL,
    [DateJoined]  NVARCHAR (10) NOT NULL,
    [LoginStatus] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Member_Id] ASC)
);


CREATE TABLE [dbo].[LevelTable] (
    [Level_Id] INT IDENTITY (1,1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Level_Id] ASC)
);


CREATE TABLE [dbo].[LessonTable] (
    [Lesson_Id]     INT            IDENTITY (1, 1) NOT NULL,
    [English_Title] NVARCHAR (MAX) NOT NULL,
    [Chinese_Title] NVARCHAR (MAX) NOT NULL,
    [LessonImage]      VARCHAR (MAX)   NOT NULL,
    [Level_Id] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Lesson_Id] ASC),
    FOREIGN KEY ([Level_Id]) 
        REFERENCES [dbo].[LevelTable] ([Level_Id]) 
        ON DELETE CASCADE
);

INSERT INTO LessonTable ([English_Title],[Chinese_Title],[LessonImage],[Level_Id]) VALUES ('english',N'中文','~/Lesson_Img/What is your favorite food.jpg',1);
DELETE FROM LessonTable WHERE Lesson_Id = 1;

SELECT * FROM LessonTable
SELECT * FROM LevelTable
SELECT * FROM AdminTable


DROP TABLE [dbo].[LessonContent]
DROP TABLE [dbo].[LessonTable]

CREATE TABLE [dbo].[LessonContent] (
    [LessonContent_Id] INT IDENTITY (1,1) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [Pinyin] NVARCHAR (MAX) NOT NULL,
    [Translation] NVARCHAR (MAX) NOT NULL,
    [Lesson_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([LessonContent_Id] ASC),
    FOREIGN KEY([Lesson_Id])
        REFERENCES [dbo].[LessonTable]
        ON DELETE CASCADE
);

CREATE TABLE [dbo].[GrammarTable] (
    [Grammar_Id] INT IDENTITY (1,1) NOT NULL,
    [Chinese_Title] NVARCHAR (MAX) NOT NULL,
    [English_Title] NVARCHAR (MAX) NOT NULL,
    [Level_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Grammar_Id] ASC),
    FOREIGN KEY ([Level_Id])
        REFERENCES [dbo].[LevelTable]
        ON DELETE CASCADE
);


CREATE TABLE [dbo].[GrammarContent] (
    [GrammarContent_Id] INT IDENTITY (1,1) NOT NULL,
    [SubHeading] NVARCHAR (MAX) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [Example] NVARCHAR (MAX) NOT NULL,
    [Grammar_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([GrammarContent_Id] ASC),
    FOREIGN KEY ([Grammar_Id])
        REFERENCES [dbo].[GrammarTable]
        ON DELETE CASCADE
);


CREATE TABLE [dbo].[QuestionTable] (
    [Question_Id] INT IDENTITY (1,1) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [FirstChoice] NVARCHAR (MAX) NOT NULL,
    [SecondChoice] NVARCHAR (MAX) NOT NULL,
    [ThirdChoice] NVARCHAR (MAX) NOT NULL,
    [Answer] NVARCHAR (MAX),
    [ReadingTest_Id] INT NULL,
    PRIMARY KEY CLUSTERED ([Question_Id] ASC), 
    FOREIGN KEY ([ReadingTest_Id])
        REFERENCES [dbo].[ReadingTest]
        ON DELETE CASCADE
)

INSERT INTO [dbo].[QuestionTable] (
    [Content],[FirstChoice],[SecondChoice],[ThirdChoice],[Answer],[ReadingTest_Id]
) VALUES (N'他的名字是？','A. HAHA', 'B.HEHE', 'C.JAJA', 'A. HAHA', 1);

INSERT INTO [dbo].[QuestionTable] (
    [Content],[FirstChoice],[SecondChoice],[ThirdChoice],[Answer],[ReadingTest_Id]
) VALUES (N'他的名字是？',N'娜娜', N'咯与啊', N'地东坡撒', N'地东坡撒', 1);

INSERT INTO [dbo].[QuestionTable] (
    [Content],[FirstChoice],[SecondChoice],[ThirdChoice],[Answer],[ReadingTest_Id]
) VALUES (N'他的名字是？',N'爱爸爸', N'啊妈妈', N'哎哟哟哟', N'啊妈妈', 1);



SELECT * FROM ReadingTest
SELECT * FROM QuestionTable

CREATE TABLE [dbo].[ReadingTest] (
    [ReadingTest_Id] INT IDENTITY (1,1) NOT NULL,
    [TestText] NVARCHAR (MAX) NOT NULL,
    Level_Id INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ReadingTest_Id] ASC),
    FOREIGN KEY([Level_Id])
        REFERENCES [dbo].[LevelTable]
        ON DELETE CASCADE
)

CREATE TABLE [dbo].[VocabularyWord] (
    [VocabularyWord_Id] INT IDENTITY (1,1) NOT NULL,
    [ChineseWord] NVARCHAR (MAX) NOT NULL,
    [Pinyin] NVARCHAR (MAX) NOT NULL,
    [EnglishText] NVARCHAR (MAX) NOT NULL,
    Level_Id INT NOT NULL,
    PRIMARY KEY CLUSTERED ([VocabularyWord_Id] ASC),
    FOREIGN KEY([Level_Id])
        REFERENCES [dbo].[LevelTable]
        ON DELETE CASCADE
)

SELECT * FROM [dbo].[VocabularyWord]

INSERT INTO [dbo].[VocabularyWord] (
    [ChineseWord],[Pinyin],[EnglishText],[Level_Id] 
) VALUES (N'爱','ài','love',1);

INSERT INTO [dbo].[VocabularyWord] (
    [ChineseWord],[Pinyin],[EnglishText],[Level_Id] 
) VALUES (N'保安','bǎo ān','security guard; public security; ensure safety',3);

SELECT * FROM Discussion

CREATE TABLE [dbo].[Discussion] (
    [Discussion_Id] INT IDENTITY (1,1) NOT NULL,
    [Title] NVARCHAR (MAX) NOT NULL,
    [Content] NVARCHAR (MAX) NOT NULL,
    [Date_Created] NVARCHAR (MAX) NOT NULL,
    [Status] NVARCHAR (40) NOT NULL,
    [Member_Id] INT NULL,
    PRIMARY KEY CLUSTERED ([Discussion_Id] ASC),
    FOREIGN KEY([Member_Id])
        REFERENCES [dbo].[MemberTable]
        ON DELETE CASCADE
)

CREATE TABLE [dbo].[CommentTable] (
    [Comment_Id] INT IDENTITY (1,1) NOT NULL,
    [CommentText] NVARCHAR (MAX) NOT NULL,
    [Date_Created] NVARCHAR (MAX) NOT NULL,
    [Discussion_Id] INT NOT NULL,
    [Member_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Comment_Id] ASC),
    FOREIGN KEY ([Discussion_Id])
        REFERENCES [dbo].[Discussion]
        ON DELETE CASCADE,
    FOREIGN KEY ([Member_Id])
        REFERENCES [dbo].[MemberTable]
)

SELECT * FROM ReadingTest

INSERT INTO ReadingTest (TestText, Level_Id) VALUES (N'小明: 小红，你知道吗？最近我开始注重健康饮食了。

小红: 真的吗？那你都吃些什么？',2)


INSERT INTO [dbo].[GrammarTable] ([Chinese_Title],[English_Title],[Level_Id])
VALUES ('Title2','Text2',1);

INSERT INTO [dbo].[GrammarTable] ([Chinese_Title],[English_Title],[Level_Id])
VALUES ('Title3','Text3',2);

INSERT INTO [dbo].[GrammarTable] ([Chinese_Title],[English_Title],[Level_Id])
VALUES ('Title4','Text4',1);

SELECT * FROM GrammarTable

SELECT * FROM GrammarContent



INSERT INTO [dbo].[LessonLevelTable] ([Name], [Lesson_Id])
VALUES ('Lesson Level 1', 3);

SELECT * FROM LessonTable

SELECT * FROM LevelTable

SELECT * FROM ReadingTest


SELECT * FROM GrammarTable

SELECT * FROM QuestionTable

SELECT * FROM GrammarContent

SELECT * FROM Discussion

SELECT lt.Name AS levelName, COUNT(qt.Question_Id) AS QuestionCount FROM LevelTable lt
JOIN ReadingTest rt ON lt.Level_Id = rt.Level_Id
JOIN QuestionTable qt ON rt.ReadingTest_Id = qt.ReadingTest_Id
GROUP BY lt.Name