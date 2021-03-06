USE [KBZPj]
GO
/****** Object:  Table [dbo].[tbl_Calendar]    Script Date: 4/18/2022 4:45:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Calendar](
	[CalendarId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[LeaveType] [nvarchar](20) NULL,
	[UserId] [nvarchar](50) NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_Calendar_1] PRIMARY KEY CLUSTERED 
(
	[CalendarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Employee]    Script Date: 4/18/2022 4:45:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Gender] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[CreadedDateTime] [datetime] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[UserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Employee_1] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LeaveRequest]    Script Date: 4/18/2022 4:45:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LeaveRequest](
	[LeaveRequestId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[LeaveType] [nvarchar](20) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Notes] [nvarchar](200) NULL,
	[CreadedDateTime] [datetime] NULL,
	[UpdatedDateTime] [datetime] NULL,
	[UserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_LeaveRequest] PRIMARY KEY CLUSTERED 
(
	[LeaveRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PublicHolidays]    Script Date: 4/18/2022 4:45:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PublicHolidays](
	[PublicHolidaysId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[UserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_PublicHolidays] PRIMARY KEY CLUSTERED 
(
	[PublicHolidaysId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Vw_Calendar]    Script Date: 4/18/2022 4:45:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vw_Calendar]
AS
SELECT dbo.tbl_LeaveRequest.FromDate AS Expr1, dbo.tbl_LeaveRequest.*, dbo.tbl_PublicHolidays.PublicHolidaysId, dbo.tbl_PublicHolidays.Name, dbo.tbl_PublicHolidays.Date
FROM     dbo.tbl_LeaveRequest INNER JOIN
                  dbo.tbl_PublicHolidays ON dbo.tbl_LeaveRequest.UserId = dbo.tbl_PublicHolidays.UserId
GO
SET IDENTITY_INSERT [dbo].[tbl_Calendar] ON 

INSERT [dbo].[tbl_Calendar] ([CalendarId], [Name], [Date], [LeaveType], [UserId], [EndDate]) VALUES (1, N'Mahar ThaKyan', CAST(N'2022-04-13T00:00:00.000' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432', NULL)
INSERT [dbo].[tbl_Calendar] ([CalendarId], [Name], [Date], [LeaveType], [UserId], [EndDate]) VALUES (2, N'Mahar ThaKyan', CAST(N'2022-04-14T00:00:00.000' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432', NULL)
INSERT [dbo].[tbl_Calendar] ([CalendarId], [Name], [Date], [LeaveType], [UserId], [EndDate]) VALUES (3, N'Mahar ThaKyan', CAST(N'2022-04-15T00:00:00.000' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432', NULL)
INSERT [dbo].[tbl_Calendar] ([CalendarId], [Name], [Date], [LeaveType], [UserId], [EndDate]) VALUES (4, N'Mahar ThaKyan', CAST(N'2022-04-16T00:00:00.000' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432', NULL)
INSERT [dbo].[tbl_Calendar] ([CalendarId], [Name], [Date], [LeaveType], [UserId], [EndDate]) VALUES (5, N'Mahar ThaKyan', CAST(N'2022-04-17T00:00:00.000' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432', NULL)
INSERT [dbo].[tbl_Calendar] ([CalendarId], [Name], [Date], [LeaveType], [UserId], [EndDate]) VALUES (6, N'La La', CAST(N'2022-04-19T00:00:00.000' AS DateTime), N'Annual Leave', N'89385865-0E5C-4235-A599-1EE8A2EFE432', CAST(N'2022-04-19T00:00:00.000' AS DateTime))
INSERT [dbo].[tbl_Calendar] ([CalendarId], [Name], [Date], [LeaveType], [UserId], [EndDate]) VALUES (7, N'Mya', CAST(N'2022-04-18T00:00:00.000' AS DateTime), N'Sick Leave', N'89385865-0E5C-4235-A599-1EE8A2EFE432', CAST(N'2022-04-18T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_Calendar] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Employee] ON 

INSERT [dbo].[tbl_Employee] ([EmployeeId], [EmployeeName], [Age], [Gender], [PhoneNumber], [Email], [CreadedDateTime], [UpdatedDateTime], [UserId]) VALUES (1, N'La La', 19, N'Female', N'09123456789', N'lala@gmail.com', CAST(N'2022-04-18T03:59:37.093' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432')
INSERT [dbo].[tbl_Employee] ([EmployeeId], [EmployeeName], [Age], [Gender], [PhoneNumber], [Email], [CreadedDateTime], [UpdatedDateTime], [UserId]) VALUES (2, N'Mg Mg', 25, N'Male', N'09987654321', N'mgmg@gmail.com', CAST(N'2022-04-18T04:00:22.423' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432')
INSERT [dbo].[tbl_Employee] ([EmployeeId], [EmployeeName], [Age], [Gender], [PhoneNumber], [Email], [CreadedDateTime], [UpdatedDateTime], [UserId]) VALUES (3, N'Naing ', 19, N'Male', N'09942156789', N'naing@gmail.com', CAST(N'2022-04-18T04:01:16.597' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432')
INSERT [dbo].[tbl_Employee] ([EmployeeId], [EmployeeName], [Age], [Gender], [PhoneNumber], [Email], [CreadedDateTime], [UpdatedDateTime], [UserId]) VALUES (4, N'Mya', 28, N'Female', N'09253146789', N'mya@gmail.com', CAST(N'2022-04-18T04:02:10.660' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432')
SET IDENTITY_INSERT [dbo].[tbl_Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_LeaveRequest] ON 

INSERT [dbo].[tbl_LeaveRequest] ([LeaveRequestId], [EmployeeName], [Department], [LeaveType], [FromDate], [ToDate], [Notes], [CreadedDateTime], [UpdatedDateTime], [UserId]) VALUES (1, N'La La', N'IT', N'Annual Leave', CAST(N'2022-04-19T00:00:00.000' AS DateTime), CAST(N'2022-04-19T00:00:00.000' AS DateTime), N'sick', CAST(N'2022-04-18T04:08:22.473' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432')
INSERT [dbo].[tbl_LeaveRequest] ([LeaveRequestId], [EmployeeName], [Department], [LeaveType], [FromDate], [ToDate], [Notes], [CreadedDateTime], [UpdatedDateTime], [UserId]) VALUES (2, N'Mya', N'IT', N'Sick Leave', CAST(N'2022-04-18T00:00:00.000' AS DateTime), CAST(N'2022-04-18T00:00:00.000' AS DateTime), N'sick', CAST(N'2022-04-18T04:09:14.143' AS DateTime), NULL, N'89385865-0E5C-4235-A599-1EE8A2EFE432')
SET IDENTITY_INSERT [dbo].[tbl_LeaveRequest] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_PublicHolidays] ON 

INSERT [dbo].[tbl_PublicHolidays] ([PublicHolidaysId], [Name], [Date], [UserId]) VALUES (1, N'Mahar ThaKyan', CAST(N'2022-04-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tbl_PublicHolidays] ([PublicHolidaysId], [Name], [Date], [UserId]) VALUES (2, N'Mahar ThaKyan', CAST(N'2022-04-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tbl_PublicHolidays] ([PublicHolidaysId], [Name], [Date], [UserId]) VALUES (3, N'Mahar ThaKyan', CAST(N'2022-04-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tbl_PublicHolidays] ([PublicHolidaysId], [Name], [Date], [UserId]) VALUES (4, N'Mahar ThaKyan', CAST(N'2022-04-16T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tbl_PublicHolidays] ([PublicHolidaysId], [Name], [Date], [UserId]) VALUES (5, N'Mahar ThaKyan', CAST(N'2022-04-17T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tbl_PublicHolidays] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_LeaveRequest"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 266
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "tbl_PublicHolidays"
            Begin Extent = 
               Top = 7
               Left = 314
               Bottom = 170
               Right = 520
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Calendar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Calendar'
GO
