USE [RMATracker_dev]
GO

/****** Object:  Table [dbo].[BankInfo]    Script Date: 9/25/2018 10:32:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BankInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](50) NULL,
	[BankStreetAddress] [varchar](255) NULL,
	[BankCity] [varchar](50) NULL,
	[BankState] [varchar](50) NULL,
	[BankZipCode] [varchar](10) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_BankInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Dates]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ReceivedDate] [datetime] NULL,
	[ShippingDate] [datetime] NULL,
	[MFGDate] [datetime] NULL,
	[CaseDate] [datetime] NULL,
	[TestDate] [datetime] NULL,
	[ReworkDate] [datetime] NULL,
	[DateCreated] [datetime] NULL,
	[ParabitCalledDate] [datetime] NULL,
 CONSTRAINT [PK_Dates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EMails]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EMails](
	[Addresses] [varchar](255) NULL,
	[MsgBody] [text] NULL,
	[EmailType] [varchar](15) NULL,
	[TimeSent] [datetime] NULL,
	[rma_id] [int] NULL,
	[registration_id] [int] NULL,
	[survey_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Forms]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Forms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[form_name] [varchar](50) NULL,
	[form_title] [varchar](50) NULL,
	[email_address] [varchar](50) NULL,
	[email_name] [varchar](50) NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Parts]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rma_id] [int] NULL,
	[part_types_id] [int] NULL,
	[serial_no] [char](6) NULL,
	[seq_no] [int] NULL,
	[DateCreated] [datetime] NULL,
	[image_path] [varchar](255) NULL,
	[image_description] [varchar](255) NULL,
	[status_id] [int] NULL,
	[additional_notes] [varchar](255) NULL,
 CONSTRAINT [PK_Parts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PartTypes]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PartTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PartNo] [varchar](20) NULL,
	[PartDescription] [varchar](50) NULL,
 CONSTRAINT [PK_PartTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ProblemTypes]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProblemTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[problem_description] [varchar](100) NULL,
 CONSTRAINT [PK_Problems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[RegisteredParts]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RegisteredParts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[registration_id] [int] NULL,
	[part_types_id] [int] NULL,
	[serial_no] [char](6) NULL,
	[seq_no] [int] NULL,
	[image_path] [varchar](255) NULL,
	[image_description] [varchar](255) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_RegisteredParts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Registrations]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Registrations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[registration_no] [varchar](10) NULL,
	[date_installed] [datetime] NULL,
	[bankinfo_id] [int] NULL,
	[tech_info_id] [int] NULL,
	[date_created] [datetime] NULL,
 CONSTRAINT [PK_Installations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ReturnAddress]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReturnAddress](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [varchar](255) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_ReturnAddress] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[RMABase]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RMABase](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status_id] [int] NULL,
	[rma_no] [char](6) NULL,
	[tr_no] [char](12) NULL,
	[case_no] [int] NULL,
	[date_submitted] [datetime] NULL,
	[date_created] [datetime] NULL,
	[rma_details_id] [int] NULL,
	[bankinfo_id] [int] NULL,
	[assessment_id] [int] NULL,
	[dates_id] [int] NULL,
	[putty_test_id] [int] NULL,
	[tech_info_id] [int] NULL,
	[test_results_id] [int] NULL,
	[return_address_id] [int] NULL,
	[was_parabit_called] [bit] NULL,
	[DispatchNo] [varchar](20) NULL,
	[form_id] [int] NULL,
	[problem_id] [int] NULL,
 CONSTRAINT [PK_RMAs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[RMADetails]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RMADetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ReturnType] [int] NULL,
	[CreditReason] [int] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_RMADetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Statuses]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Statuses](
	[id] [int] NOT NULL,
	[status] [varchar](100) NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Survey]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Survey](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[survey_date] [datetime] NULL,
	[tech_name] [varchar](50) NULL,
	[requestor] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [nchar](10) NULL,
	[problem_reporter] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[requester_problem] [varchar](255) NULL,
	[contact_problem] [varchar](255) NULL,
	[existing_firm_version] [varchar](10) NULL,
	[new_firm_version] [varchar](10) NULL,
	[card_reader_writing] [varchar](10) NULL,
	[physical_int_devices] [varchar](255) NULL,
	[elecrtrical_int_devices] [varchar](255) NULL,
	[is_mounted] [bit] NULL,
	[heartbeat_main] [varchar](50) NULL,
	[heartbeat_rs485] [varchar](50) NULL,
	[alarm_tamper] [varchar](50) NULL,
	[alarm_overlay] [varchar](50) NULL,
	[alarm_cable_cut] [varchar](50) NULL,
	[alarm_relay1] [varchar](50) NULL,
	[alarm_relay2] [varchar](50) NULL,
	[alarm_relay3] [varchar](50) NULL,
	[heartbeat_main_other] [varchar](50) NULL,
	[heartbeat_rs485_other] [varchar](50) NULL,
	[alarm_tamper_other] [varchar](50) NULL,
	[alarm_overlay_other] [varchar](50) NULL,
	[alarm_cable_cut_other] [varchar](50) NULL,
	[alarm_relay1_other] [varchar](50) NULL,
	[alarm_relay2_other] [varchar](50) NULL,
	[alarm_relay3_other] [varchar](50) NULL,
	[client_able_connect] [bit] NULL,
	[retrieve_ip_completed] [bit] NULL,
	[trail_file_name1] [varchar](50) NULL,
	[trail_file_name2] [varchar](50) NULL,
	[client_contact] [varchar](50) NULL,
	[integrity_check6_image_path] [varchar](255) NULL,
	[pair1_ohms] [decimal](8, 2) NULL,
	[pair2_ohms] [decimal](8, 2) NULL,
	[pair3_ohms] [decimal](8, 2) NULL,
	[pair4_ohms] [decimal](8, 2) NULL,
	[cable_origin] [int] NULL,
	[cable_gauge] [bit] NULL,
	[cable_gauge_other] [varchar](20) NULL,
	[has_twisted_pairs] [bit] NULL,
	[replacement_needed] [bit] NULL,
	[new_cable_installed] [bit] NULL,
	[visit_reqs] [char](6) NULL,
	[is_cable_picture_taken] [bit] NULL,
	[cable_picture_path] [varchar](255) NULL,
	[unique_reqs] [varchar](255) NULL,
	[overlay_activity] [varchar](255) NULL,
	[obstructions_found] [bit] NULL,
	[obstructions_found_notes] [varchar](255) NULL,
	[is_obstr_picture_taken] [bit] NULL,
	[obstr_picture_path] [varchar](255) NULL,
	[obstructions_reported] [bit] NULL,
	[obstructions_reported_notes] [varchar](255) NULL,
	[additional_findings] [varchar](255) NULL,
	[new_serial_reader1] [char](6) NULL,
	[new_serial_reader2] [char](6) NULL,
	[tamper_observations] [varchar](255) NULL,
	[continuity_test_ok] [bit] NULL,
	[changed_switch1] [bit] NULL,
	[joint_show_damage] [bit] NULL,
	[changed_switch2] [bit] NULL,
	[replaced_mmr_reader] [bit] NULL,
	[replaced_collar] [bit] NULL,
	[inspection_results] [varchar](255) NULL,
	[inspection_picture_taken] [bit] NULL,
	[inspection_picture_path] [varchar](255) NULL,
	[serial_shunted] [bit] NULL,
	[serial_shunted_results] [varchar](255) NULL,
	[branch_staff_name] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Survey_temp]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Survey_temp](
	[id] [int] NOT NULL,
	[survey_date] [datetime] NULL,
	[tech_name] [varchar](50) NULL,
	[requestor] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [nchar](10) NULL,
	[requester_problem] [varchar](255) NULL,
	[problem_reporter] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[contact_problem] [varchar](255) NULL,
	[heartbeat_main] [varchar](50) NULL,
	[heartbeat_rs485] [varchar](50) NULL,
	[alarm_tamper] [varchar](50) NULL,
	[alarm_overlay] [varchar](50) NULL,
	[alarm_cable_cut] [varchar](50) NULL,
	[alarm_relay1] [varchar](50) NULL,
	[alarm_relay2] [varchar](50) NULL,
	[alarm_relay3] [varchar](50) NULL,
	[client_able_connect] [bit] NULL,
	[retrieve_ip_completed] [bit] NULL,
	[trail_file_name1] [varchar](50) NULL,
	[trail_file_name2] [varchar](50) NULL,
	[client_contact] [varchar](50) NULL,
	[image_path_check6] [varchar](255) NULL,
	[pair1_ohms] [varchar](10) NULL,
	[pair2_ohms] [varchar](10) NULL,
	[pair3_ohms] [varchar](10) NULL,
	[pair4_ohms] [varchar](10) NULL,
	[cable_origin] [int] NULL,
	[cable_gauge] [int] NULL,
	[has_twisted_pairs] [bit] NULL,
	[replacement_needed] [bit] NULL,
	[new_cable_installed] [bit] NULL,
	[visit_reqs] [char](6) NULL,
	[is_cable_picture_taken] [bit] NULL,
	[cable_picture_path] [varchar](255) NULL,
	[unique_reqs] [varchar](255) NULL,
	[overlay_activity] [varchar](255) NULL,
	[obstructions_found] [bit] NULL,
	[obstructions_found_notes] [varchar](255) NULL,
	[is_obstr_picture_taken] [bit] NULL,
	[obstr_picture_path1] [varchar](255) NULL,
	[obstructions_reported] [bit] NULL,
	[obstructions_reported_notes] [varchar](255) NULL,
	[DateCreated] [datetime] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SurveyIntegrityChecks]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurveyIntegrityChecks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NULL,
	[seq_no] [int] NULL,
	[integrity_check] [bit] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_SurveyIntegrityChecks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SurveyObstructions]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurveyObstructions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[seq_no] [int] NULL,
	[yes_no] [bit] NULL,
	[description] [varchar](255) NULL,
	[is_picture_taken] [bit] NULL,
	[picture_path] [varchar](255) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_SurveyObstructions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SurveyReaderArrivalStates]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurveyReaderArrivalStates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[seq_no] [int] NULL,
	[reader_green] [bit] NULL,
	[reader_green_schedule] [bit] NULL,
	[reader_amber] [bit] NULL,
	[reader_amber_schedule] [bit] NULL,
	[reader_red] [bit] NULL,
	[reader_red_schedule] [bit] NULL,
	[reader_blinking_red] [bit] NULL,
	[reader_blinking_red_schedule] [bit] NULL,
	[reader_other] [varchar](50) NULL,
	[reader_success1] [bit] NULL,
	[reader_success2] [bit] NULL,
	[reader_notes] [varchar](255) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_SurveyReaderArrivalStates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SurveySiteInspection]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurveySiteInspection](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[reader1_serial] [char](6) NULL,
	[reader1_image_path] [varchar](255) NULL,
	[reader1_image_description] [varchar](255) NULL,
	[reader2_serial] [char](6) NULL,
	[reader2_image_path] [varchar](255) NULL,
	[reader2_image_description] [varchar](255) NULL,
	[controller_serial] [char](6) NULL,
	[controller_image_path] [varchar](255) NULL,
	[controller_image_description] [varchar](255) NULL,
	[existing_firm_version] [varchar](10) NULL,
	[ups_present] [bit] NULL,
	[ups_installed] [bit] NULL,
	[new_firm_version] [varchar](10) NULL,
	[card_reader_wiring] [varchar](20) NULL,
	[card_reader_wiring_image_desc] [varchar](20) NULL,
	[card_reader_wiring_image_path] [varchar](255) NULL,
	[physical_int_devices] [varchar](255) NULL,
	[elecrtrical_int_devices] [varchar](255) NULL,
	[is_mounted] [bit] NULL,
	[supply_needed] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_SurveySiteInspection] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SurveyTemplateSets]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SurveyTemplateSets](
	[seq_no] [int] NULL,
	[set_type] [varchar](25) NULL,
	[message] [varchar](255) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TechInfo]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TechInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TechName] [varchar](50) NULL,
	[TechEmail] [varchar](50) NULL,
	[TechPhone] [varchar](50) NULL,
	[ClientName] [varchar](50) NULL,
	[ClientComplaint] [varchar](50) NULL,
	[ImageFile] [image] NULL,
	[FieldObservation] [varchar](255) NULL,
	[StepsUndertaken] [varchar](255) NULL,
	[ComplaintConfirmed] [bit] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Tests]    Script Date: 9/25/2018 10:32:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TestResults] [varchar](50) NULL,
	[FactoryTech] [varchar](50) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_TestRedsults] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BankInfo] ADD  CONSTRAINT [DF_Bank_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[Dates] ADD  CONSTRAINT [DF_Dates_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[EMails] ADD  CONSTRAINT [DF_EMails_TimeSent]  DEFAULT (getdate()) FOR [TimeSent]
GO

ALTER TABLE [dbo].[Parts] ADD  CONSTRAINT [DF_Parts_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[RegisteredParts] ADD  CONSTRAINT [DF_RegisteredParts_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[Registrations] ADD  CONSTRAINT [DF_Installations_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[ReturnAddress] ADD  CONSTRAINT [DF_ReturnAddress_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[RMABase] ADD  CONSTRAINT [DF_RMAs_DateCreated]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[RMADetails] ADD  CONSTRAINT [DF_RMADetails_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[Survey] ADD  CONSTRAINT [DF_Table_1_DateCreated1]  DEFAULT (getdate()) FOR [survey_date]
GO

ALTER TABLE [dbo].[Survey] ADD  CONSTRAINT [DF_Survey_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[SurveyIntegrityChecks] ADD  CONSTRAINT [DF_SurveyIntegrityChecks_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[SurveyObstructions] ADD  CONSTRAINT [DF_SurveyObstructions_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[SurveyReaderArrivalStates] ADD  CONSTRAINT [DF_SurveyReaderArrivalStates_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[SurveySiteInspection] ADD  CONSTRAINT [DF_SurveySiteInspection_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[TechInfo] ADD  CONSTRAINT [DF_Client_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_TestRedsults_FactoryTech]  DEFAULT ('DB') FOR [FactoryTech]
GO

ALTER TABLE [dbo].[Tests] ADD  CONSTRAINT [DF_TestResults_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[EMails]  WITH CHECK ADD  CONSTRAINT [FK_EMails_Registrations] FOREIGN KEY([registration_id])
REFERENCES [dbo].[Registrations] ([id])
GO

ALTER TABLE [dbo].[EMails] CHECK CONSTRAINT [FK_EMails_Registrations]
GO

ALTER TABLE [dbo].[EMails]  WITH CHECK ADD  CONSTRAINT [FK_EMails_RMABase] FOREIGN KEY([rma_id])
REFERENCES [dbo].[RMABase] ([id])
GO

ALTER TABLE [dbo].[EMails] CHECK CONSTRAINT [FK_EMails_RMABase]
GO

ALTER TABLE [dbo].[EMails]  WITH CHECK ADD  CONSTRAINT [FK_EMails_Survey] FOREIGN KEY([survey_id])
REFERENCES [dbo].[Survey] ([id])
GO

ALTER TABLE [dbo].[EMails] CHECK CONSTRAINT [FK_EMails_Survey]
GO

ALTER TABLE [dbo].[Parts]  WITH CHECK ADD  CONSTRAINT [FK_Parts_PartTypes] FOREIGN KEY([part_types_id])
REFERENCES [dbo].[PartTypes] ([id])
GO

ALTER TABLE [dbo].[Parts] CHECK CONSTRAINT [FK_Parts_PartTypes]
GO

ALTER TABLE [dbo].[Parts]  WITH CHECK ADD  CONSTRAINT [FK_Parts_RMABase] FOREIGN KEY([rma_id])
REFERENCES [dbo].[RMABase] ([id])
GO

ALTER TABLE [dbo].[Parts] CHECK CONSTRAINT [FK_Parts_RMABase]
GO

ALTER TABLE [dbo].[Parts]  WITH CHECK ADD  CONSTRAINT [FK_Parts_Statuses] FOREIGN KEY([status_id])
REFERENCES [dbo].[Statuses] ([id])
GO

ALTER TABLE [dbo].[Parts] CHECK CONSTRAINT [FK_Parts_Statuses]
GO

ALTER TABLE [dbo].[RegisteredParts]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredParts_PartTypes] FOREIGN KEY([part_types_id])
REFERENCES [dbo].[PartTypes] ([id])
GO

ALTER TABLE [dbo].[RegisteredParts] CHECK CONSTRAINT [FK_RegisteredParts_PartTypes]
GO

ALTER TABLE [dbo].[RegisteredParts]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredParts_Registrations] FOREIGN KEY([registration_id])
REFERENCES [dbo].[Registrations] ([id])
GO

ALTER TABLE [dbo].[RegisteredParts] CHECK CONSTRAINT [FK_RegisteredParts_Registrations]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMABase_Forms] FOREIGN KEY([form_id])
REFERENCES [dbo].[Forms] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMABase_Forms]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMABase_Statuses] FOREIGN KEY([status_id])
REFERENCES [dbo].[Statuses] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMABase_Statuses]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMABase_TechInfo] FOREIGN KEY([tech_info_id])
REFERENCES [dbo].[TechInfo] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMABase_TechInfo]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMAs_Assessment] FOREIGN KEY([return_address_id])
REFERENCES [dbo].[ReturnAddress] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMAs_Assessment]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMAs_BankInfo] FOREIGN KEY([bankinfo_id])
REFERENCES [dbo].[BankInfo] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMAs_BankInfo]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMAs_Dates] FOREIGN KEY([dates_id])
REFERENCES [dbo].[Dates] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMAs_Dates]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMAs_RMADetails] FOREIGN KEY([rma_details_id])
REFERENCES [dbo].[RMADetails] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMAs_RMADetails]
GO

ALTER TABLE [dbo].[RMABase]  WITH CHECK ADD  CONSTRAINT [FK_RMAs_RMAs5] FOREIGN KEY([putty_test_id])
REFERENCES [dbo].[_PuttyTest] ([id])
GO

ALTER TABLE [dbo].[RMABase] CHECK CONSTRAINT [FK_RMAs_RMAs5]
GO

ALTER TABLE [dbo].[SurveyObstructions]  WITH CHECK ADD  CONSTRAINT [FK_SurveyObstructions_Survey] FOREIGN KEY([survey_id])
REFERENCES [dbo].[Survey] ([id])
GO

ALTER TABLE [dbo].[SurveyObstructions] CHECK CONSTRAINT [FK_SurveyObstructions_Survey]
GO

