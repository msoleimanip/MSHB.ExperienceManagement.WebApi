USE [ExperienceManagement]
GO
SET IDENTITY_INSERT [dbo].[ReportStructure_T] ON 

INSERT [dbo].[ReportStructure_T] ([Id], [ReportId], [Configuration], [ProtoType], [CreationDate], [LastUpdatedDateTime]) VALUES (3, N'IssueOfUsers', N'{
  "ReportVersion": "2019.3.2",
  "ReportGuid": "9317c1abf05549c1ef3008f5cf1b84fa",
  "ReportName": "Report",
  "ReportAlias": "Report",
  "ReportFile": "Report.mrt",
  "ReportCreated": "/Date(1564247880000+0430)/",
  "ReportChanged": "/Date(1564247880000+0430)/",
  "EngineVersion": "EngineV2",
  "CalculationMode": "Interpretation",
  "ReportUnit": "Centimeters",
  "PreviewSettings": 268435455,
  "Dictionary": {
    "DataSources": {
      "0": {
        "Ident": "StiDataTableSource",
        "Name": "root",
        "Alias": "root",
        "Columns": {
          "0": {
            "Name": "totalIssueCount",
            "Index": -1,
            "NameInSource": "totalIssueCount",
            "Alias": "totalIssueCount",
            "Type": "System.Decimal"
          },
          "1": {
            "Name": "totalIssueUserDetails",
            "Index": -1,
            "NameInSource": "totalIssueUserDetails",
            "Alias": "totalIssueUserDetails",
            "Type": "System.Decimal"
          },
          "2": {
            "Name": "organizationName",
            "Index": -1,
            "NameInSource": "organizationName",
            "Alias": "organizationName",
            "Type": "System.String"
          },
          "3": {
            "Name": "fullName",
            "Index": -1,
            "NameInSource": "fullName",
            "Alias": "fullName",
            "Type": "System.String"
          }
        },
        "NameInSource": "SimpleDataSet.root"
      }
    }
  },
  "Pages": {
    "0": {
      "Ident": "StiPage",
      "Name": "Page1",
      "Guid": "41c22bda81cfc365f887207215f68280",
      "Interaction": {
        "Ident": "StiInteraction"
      },
      "Border": ";;2;;;;;solid:Black",
      "Brush": "solid:Transparent",
      "Components": {
        "0": {
          "Ident": "StiHeaderBand",
          "Name": "Headerroot",
          "ClientRectangle": "0,0.4,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueCount",
              "Guid": "45762819b7edd9ebfdf32868a76cd6cc",
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueCount"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueUserDetails",
              "Guid": "19f2f7a9d92e4171d13001da6260af24",
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueUserDetails"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Headerroot_organizationName",
              "Guid": "386f35d1b743f5b63974045872cd0b8e",
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "organizationName"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Headerroot_fullName",
              "Guid": "7ae4c2696068d91c06c4a8f6cc4fb298",
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "نام و نام خانوادگی"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              },
              "Type": "Expression"
            }
          }
        },
        "1": {
          "Ident": "StiDataBand",
          "Name": "Dataroot",
          "ClientRectangle": "0,2,19.01,0.8",
          "Interaction": {
            "Ident": "StiBandInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueCount",
              "Guid": "0e2ceaa8608842c83365a9e9cc9175ca",
              "CanGrow": true,
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueCount}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueUserDetails",
              "Guid": "9dfedff19eefea9abd115701290aa755",
              "CanGrow": true,
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueUserDetails}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Dataroot_organizationName",
              "Guid": "b677565106546416a570868e7f4540ea",
              "CanGrow": true,
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.organizationName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Dataroot_fullName",
              "Guid": "f92343a60c7cbbdbc5503d9c1779e78f",
              "CanGrow": true,
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.fullName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          },
          "DataSourceName": "root"
        },
        "2": {
          "Ident": "StiFooterBand",
          "Name": "Footerroot",
          "ClientRectangle": "0,3.6,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueCount",
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueUserDetails",
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Footerroot_organizationName",
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Footerroot_fullName",
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        }
      },
      "PageWidth": 21.01,
      "PageHeight": 29.69,
      "Watermark": {
        "TextBrush": "solid:50,0,0,0"
      },
      "Margins": {
        "Left": 1,
        "Right": 1,
        "Top": 1,
        "Bottom": 1
      }
    }
  }
}', NULL, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-27T17:44:28.8347102' AS DateTime2))
INSERT [dbo].[ReportStructure_T] ([Id], [ReportId], [Configuration], [ProtoType], [CreationDate], [LastUpdatedDateTime]) VALUES (4, N'IssueOfEquipments', N'{
  "ReportVersion": "2019.3.2",
  "ReportGuid": "163f55f642e596eccc80f5119065275a",
  "ReportName": "Report",
  "ReportAlias": "Report",
  "ReportFile": "Report.mrt",
  "ReportCreated": "/Date(1564264080000+0430)/",
  "ReportChanged": "/Date(1564264080000+0430)/",
  "EngineVersion": "EngineV2",
  "CalculationMode": "Interpretation",
  "ReportUnit": "Centimeters",
  "PreviewSettings": 268435455,
  "Dictionary": {
    "DataSources": {
      "0": {
        "Ident": "StiDataTableSource",
        "Name": "root",
        "Alias": "root",
        "Columns": {
          "0": {
            "Name": "totalIssueCount",
            "Index": -1,
            "NameInSource": "totalIssueCount",
            "Alias": "totalIssueCount",
            "Type": "System.Decimal"
          },
          "1": {
            "Name": "totalIssueDetails",
            "Index": -1,
            "NameInSource": "totalIssueDetails",
            "Alias": "totalIssueDetails",
            "Type": "System.Decimal"
          },
          "2": {
            "Name": "totalUserDetails",
            "Index": -1,
            "NameInSource": "totalUserDetails",
            "Alias": "totalUserDetails",
            "Type": "System.Decimal"
          },
          "3": {
            "Name": "equipmentName",
            "Index": -1,
            "NameInSource": "equipmentName",
            "Alias": "equipmentName",
            "Type": "System.String"
          },
          "4": {
            "Name": "issueType",
            "Index": -1,
            "NameInSource": "issueType",
            "Alias": "issueType",
            "Type": "System.Decimal"
          }
        },
        "NameInSource": "SimpleDataSet.root"
      }
    }
  },
  "Pages": {
    "0": {
      "Ident": "StiPage",
      "Name": "Page1",
      "Guid": "41c22bda81cfc365f887207215f68280",
      "Interaction": {
        "Ident": "StiInteraction"
      },
      "Border": ";;2;;;;;solid:Black",
      "Brush": "solid:Transparent",
      "Components": {
        "0": {
          "Ident": "StiHeaderBand",
          "Name": "Headerroot",
          "ClientRectangle": "0,0.4,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueCount",
              "Guid": "42e2e369ef4372b65fea2809c2f4d30b",
              "ClientRectangle": "0,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueCount"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueDetails",
              "Guid": "8b6b874c95d280cd01cd4870d522cd94",
              "ClientRectangle": "3.8,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueDetails"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Headerroot_totalUserDetails",
              "Guid": "9301a1cbd21d482a66eb2687440c610e",
              "ClientRectangle": "7.6,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalUserDetails"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Headerroot_equipmentName",
              "Guid": "dbfccbee2b86339b496302f0aa7605e9",
              "ClientRectangle": "11.4,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "equipmentName"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Headerroot_issueType",
              "Guid": "fbc3e029170795ec9f30f493e9c217ed",
              "ClientRectangle": "15.2,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "issueType"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        },
        "1": {
          "Ident": "StiDataBand",
          "Name": "Dataroot",
          "ClientRectangle": "0,2,19.01,0.8",
          "Interaction": {
            "Ident": "StiBandInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueCount",
              "Guid": "5df21fffe5fec137d954a293400c9e23",
              "CanGrow": true,
              "ClientRectangle": "0,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueCount}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueDetails",
              "Guid": "138f7266e61a90196a2905c2edac15cd",
              "CanGrow": true,
              "ClientRectangle": "3.8,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueDetails}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Dataroot_totalUserDetails",
              "Guid": "acf77bd0b0c3bd6ec6b8409f71d4ecc8",
              "CanGrow": true,
              "ClientRectangle": "7.6,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalUserDetails}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Dataroot_equipmentName",
              "Guid": "1d46ad53ffa7a67bb009af79294e9b75",
              "CanGrow": true,
              "ClientRectangle": "11.4,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.equipmentName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Dataroot_issueType",
              "Guid": "61f6866e044568dd75a99c280d8966d6",
              "CanGrow": true,
              "ClientRectangle": "15.2,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.issueType}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          },
          "DataSourceName": "root"
        },
        "2": {
          "Ident": "StiFooterBand",
          "Name": "Footerroot",
          "ClientRectangle": "0,3.6,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueCount",
              "ClientRectangle": "0,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueDetails",
              "ClientRectangle": "3.8,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Footerroot_totalUserDetails",
              "ClientRectangle": "7.6,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Footerroot_equipmentName",
              "ClientRectangle": "11.4,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Footerroot_issueType",
              "ClientRectangle": "15.2,0,3.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        }
      },
      "PageWidth": 21.01,
      "PageHeight": 29.69,
      "Watermark": {
        "TextBrush": "solid:50,0,0,0"
      },
      "Margins": {
        "Left": 1,
        "Right": 1,
        "Top": 1,
        "Bottom": 1
      }
    }
  }
}', NULL, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-29T14:57:09.0096010' AS DateTime2))
INSERT [dbo].[ReportStructure_T] ([Id], [ReportId], [Configuration], [ProtoType], [CreationDate], [LastUpdatedDateTime]) VALUES (5, N'IssueOfUserLikes', N'{
  "ReportVersion": "2019.3.2",
  "ReportGuid": "cec5a5a687feb19b9d370a81080ffd1e",
  "ReportName": "Report",
  "ReportAlias": "Report",
  "ReportFile": "Report.mrt",
  "ReportCreated": "/Date(1564280280000+0430)/",
  "ReportChanged": "/Date(1564280280000+0430)/",
  "EngineVersion": "EngineV2",
  "CalculationMode": "Interpretation",
  "ReportUnit": "Centimeters",
  "PreviewSettings": 268435455,
  "Dictionary": {
    "DataSources": {
      "0": {
        "Ident": "StiDataTableSource",
        "Name": "root",
        "Alias": "root",
        "Columns": {
          "0": {
            "Name": "totalIssueCount",
            "Index": -1,
            "NameInSource": "totalIssueCount",
            "Alias": "totalIssueCount",
            "Type": "System.Decimal"
          },
          "1": {
            "Name": "totalUserDetails",
            "Index": -1,
            "NameInSource": "totalUserDetails",
            "Alias": "totalUserDetails",
            "Type": "System.Decimal"
          },
          "2": {
            "Name": "totalUserLikes",
            "Index": -1,
            "NameInSource": "totalUserLikes",
            "Alias": "totalUserLikes",
            "Type": "System.Decimal"
          },
          "3": {
            "Name": "issueType",
            "Index": -1,
            "NameInSource": "issueType",
            "Alias": "issueType",
            "Type": "System.Decimal"
          }
        },
        "NameInSource": "SimpleDataSet.root"
      }
    }
  },
  "Pages": {
    "0": {
      "Ident": "StiPage",
      "Name": "Page1",
      "Guid": "41c22bda81cfc365f887207215f68280",
      "Interaction": {
        "Ident": "StiInteraction"
      },
      "Border": ";;2;;;;;solid:Black",
      "Brush": "solid:Transparent",
      "Components": {
        "0": {
          "Ident": "StiHeaderBand",
          "Name": "Headerroot",
          "ClientRectangle": "0,0.4,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueCount",
              "Guid": "19e95720b857f72957dbf5507a1b4bd3",
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueCount"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Headerroot_totalUserDetails",
              "Guid": "019972f98d1da124fdeb742d27c2c6ba",
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalUserDetails"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Headerroot_totalUserLikes",
              "Guid": "493af09525dce49f426c785fdd09831e",
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalUserLikes"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Headerroot_issueType",
              "Guid": "01c2c493fec4de47f7310ae0d91aba69",
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "issueType"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        },
        "1": {
          "Ident": "StiDataBand",
          "Name": "Dataroot",
          "ClientRectangle": "0,2,19.01,0.8",
          "Interaction": {
            "Ident": "StiBandInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueCount",
              "Guid": "faf90a61b8d34de439ccfca5398e0a79",
              "CanGrow": true,
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueCount}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Dataroot_totalUserDetails",
              "Guid": "2ef24674a177a9d4b7a60da02e20c0aa",
              "CanGrow": true,
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalUserDetails}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Dataroot_totalUserLikes",
              "Guid": "8bf819653ad5b6c22a6f5052208b97b6",
              "CanGrow": true,
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalUserLikes}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Dataroot_issueType",
              "Guid": "85b32b128ee7878dbb3aa4db74b41ebe",
              "CanGrow": true,
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.issueType}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          },
          "DataSourceName": "root"
        },
        "2": {
          "Ident": "StiFooterBand",
          "Name": "Footerroot",
          "ClientRectangle": "0,3.6,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueCount",
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Footerroot_totalUserDetails",
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Footerroot_totalUserLikes",
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Footerroot_issueType",
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        }
      },
      "PageWidth": 21.01,
      "PageHeight": 29.69,
      "Watermark": {
        "TextBrush": "solid:50,0,0,0"
      },
      "Margins": {
        "Left": 1,
        "Right": 1,
        "Top": 1,
        "Bottom": 1
      }
    }
  }
}', NULL, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-29T15:03:08.4231243' AS DateTime2))
INSERT [dbo].[ReportStructure_T] ([Id], [ReportId], [Configuration], [ProtoType], [CreationDate], [LastUpdatedDateTime]) VALUES (6, N'TotalIssue', N'{
  "ReportVersion": "2019.3.2",
  "ReportGuid": "1bd9b3e50677335972e8becb6bba26ea",
  "ReportName": "Report",
  "ReportAlias": "Report",
  "ReportFile": "Report.mrt",
  "ReportCreated": "/Date(1564312680000+0430)/",
  "ReportChanged": "/Date(1564312680000+0430)/",
  "EngineVersion": "EngineV2",
  "CalculationMode": "Interpretation",
  "ReportUnit": "Centimeters",
  "PreviewSettings": 268435455,
  "Dictionary": {
    "DataSources": {
      "0": {
        "Ident": "StiDataTableSource",
        "Name": "root",
        "Alias": "root",
        "Columns": {
          "0": {
            "Name": "fullName",
            "Index": -1,
            "NameInSource": "fullName",
            "Alias": "fullName",
            "Type": "System.String"
          },
          "1": {
            "Name": "totalIssueDetails",
            "Index": -1,
            "NameInSource": "totalIssueDetails",
            "Alias": "totalIssueDetails",
            "Type": "System.Decimal"
          },
          "2": {
            "Name": "title",
            "Index": -1,
            "NameInSource": "title",
            "Alias": "title",
            "Type": "System.String"
          },
          "3": {
            "Name": "userName",
            "Index": -1,
            "NameInSource": "userName",
            "Alias": "userName",
            "Type": "System.String"
          },
          "4": {
            "Name": "likesCount",
            "Index": -1,
            "NameInSource": "likesCount",
            "Alias": "likesCount",
            "Type": "System.Decimal"
          },
          "5": {
            "Name": "creationTime",
            "Index": -1,
            "NameInSource": "creationTime",
            "Alias": "creationTime",
            "Type": "System.String"
          },
          "6": {
            "Name": "issueType",
            "Index": -1,
            "NameInSource": "issueType",
            "Alias": "issueType",
            "Type": "System.Decimal"
          }
        },
        "NameInSource": "SimpleDataSet.root"
      }
    }
  },
  "Pages": {
    "0": {
      "Ident": "StiPage",
      "Name": "Page1",
      "Guid": "41c22bda81cfc365f887207215f68280",
      "Interaction": {
        "Ident": "StiInteraction"
      },
      "Border": ";;2;;;;;solid:Black",
      "Brush": "solid:Transparent",
      "Components": {
        "0": {
          "Ident": "StiHeaderBand",
          "Name": "Headerroot",
          "ClientRectangle": "0,0.4,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Headerroot_fullName",
              "Guid": "5f80fd023054d5ab6f630b0f009546ec",
              "ClientRectangle": "0,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "fullName"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueDetails",
              "Guid": "6f7cac383043ebe29fa5d741e939cdd8",
              "ClientRectangle": "2.8,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueDetails"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Headerroot_title",
              "Guid": "af0200969a0fb32708be5379800bf117",
              "ClientRectangle": "5.6,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "title"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Headerroot_userName",
              "Guid": "17369b4fdb6a673970c2b5ae9247299e",
              "ClientRectangle": "8.4,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "userName"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Headerroot_likesCount",
              "Guid": "fef3b6fa4756bed8f139392f00d0d059",
              "ClientRectangle": "11.2,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "likesCount"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "5": {
              "Ident": "StiText",
              "Name": "Headerroot_creationTime",
              "Guid": "16d6df159aa02e658761d81fdd193854",
              "ClientRectangle": "14,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "creationTime"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "6": {
              "Ident": "StiText",
              "Name": "Headerroot_issueType",
              "Guid": "1411ddaf8ac50552483d5d28427538b9",
              "ClientRectangle": "16.8,0,2.2,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "issueType"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        },
        "1": {
          "Ident": "StiDataBand",
          "Name": "Dataroot",
          "ClientRectangle": "0,2,19.01,0.8",
          "Interaction": {
            "Ident": "StiBandInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Dataroot_fullName",
              "Guid": "0e763180c86343b5db6d15c10e2746c8",
              "CanGrow": true,
              "ClientRectangle": "0,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.fullName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueDetails",
              "Guid": "4a73e4053f6ccc6e77608a083133ad76",
              "CanGrow": true,
              "ClientRectangle": "2.8,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueDetails}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Dataroot_title",
              "Guid": "6504a05523ecd9ea686b2c806f91c66e",
              "CanGrow": true,
              "ClientRectangle": "5.6,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.title}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Dataroot_userName",
              "Guid": "48c6944827de22fa27fd52de85949c6c",
              "CanGrow": true,
              "ClientRectangle": "8.4,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.userName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Dataroot_likesCount",
              "Guid": "03cab4b703a21d2521cf49956b827e94",
              "CanGrow": true,
              "ClientRectangle": "11.2,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.likesCount}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "5": {
              "Ident": "StiText",
              "Name": "Dataroot_creationTime",
              "Guid": "af793707850b3c3a8318f962d926a13b",
              "CanGrow": true,
              "ClientRectangle": "14,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.creationTime}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "6": {
              "Ident": "StiText",
              "Name": "Dataroot_issueType",
              "Guid": "3bc6cb289cd14ab69530160f6c74be87",
              "CanGrow": true,
              "ClientRectangle": "16.8,0,2.2,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.issueType}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          },
          "DataSourceName": "root"
        },
        "2": {
          "Ident": "StiFooterBand",
          "Name": "Footerroot",
          "ClientRectangle": "0,3.6,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Footerroot_fullName",
              "ClientRectangle": "0,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueDetails",
              "ClientRectangle": "2.8,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Footerroot_title",
              "ClientRectangle": "5.6,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Footerroot_userName",
              "ClientRectangle": "8.4,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Footerroot_likesCount",
              "ClientRectangle": "11.2,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "5": {
              "Ident": "StiText",
              "Name": "Footerroot_creationTime",
              "ClientRectangle": "14,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "6": {
              "Ident": "StiText",
              "Name": "Footerroot_issueType",
              "ClientRectangle": "16.8,0,2.2,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        }
      },
      "PageWidth": 21.01,
      "PageHeight": 29.69,
      "Watermark": {
        "TextBrush": "solid:50,0,0,0"
      },
      "Margins": {
        "Left": 1,
        "Right": 1,
        "Top": 1,
        "Bottom": 1
      }
    }
  }
}', NULL, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-29T15:08:28.3616660' AS DateTime2))
INSERT [dbo].[ReportStructure_T] ([Id], [ReportId], [Configuration], [ProtoType], [CreationDate], [LastUpdatedDateTime]) VALUES (8, N'IssuesOfOrganization', N'{
  "ReportVersion": "2019.3.2",
  "ReportGuid": "a9697916e5917a21e5df8cffc773efd7",
  "ReportName": "Report",
  "ReportAlias": "Report",
  "ReportFile": "Report.mrt",
  "ReportCreated": "/Date(1564296480000+0430)/",
  "ReportChanged": "/Date(1564296480000+0430)/",
  "EngineVersion": "EngineV2",
  "CalculationMode": "Interpretation",
  "ReportUnit": "Centimeters",
  "PreviewSettings": 268435455,
  "Dictionary": {
    "DataSources": {
      "0": {
        "Ident": "StiDataTableSource",
        "Name": "root",
        "Alias": "root",
        "Columns": {
          "0": {
            "Name": "totalIssueCount",
            "Index": -1,
            "NameInSource": "totalIssueCount",
            "Alias": "totalIssueCount",
            "Type": "System.Decimal"
          },
          "1": {
            "Name": "organizationName",
            "Index": -1,
            "NameInSource": "organizationName",
            "Alias": "organizationName",
            "Type": "System.String"
          },
          "2": {
            "Name": "totalIssueDetails",
            "Index": -1,
            "NameInSource": "totalIssueDetails",
            "Alias": "totalIssueDetails",
            "Type": "System.Decimal"
          },
          "3": {
            "Name": "totalUsers",
            "Index": -1,
            "NameInSource": "totalUsers",
            "Alias": "totalUsers",
            "Type": "System.Decimal"
          }
        },
        "NameInSource": "SimpleDataSet.root"
      }
    }
  },
  "Pages": {
    "0": {
      "Ident": "StiPage",
      "Name": "Page1",
      "Guid": "41c22bda81cfc365f887207215f68280",
      "Interaction": {
        "Ident": "StiInteraction"
      },
      "Border": ";;2;;;;;solid:Black",
      "Brush": "solid:Transparent",
      "Components": {
        "0": {
          "Ident": "StiHeaderBand",
          "Name": "Headerroot",
          "ClientRectangle": "0,0.4,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueCount",
              "Guid": "797ab39c90914fb5b237c97fe48c8c29",
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueCount"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Headerroot_organizationName",
              "Guid": "f19e7fe3ab37dafeb9c90027bbb3cd70",
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "organizationName"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueDetails",
              "Guid": "d4db3770c75d468713d7c6be6ed5e7d4",
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueDetails"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Headerroot_totalUsers",
              "Guid": "a7df5250dfa8f4e3f1dea530217a1807",
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalUsers"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        },
        "1": {
          "Ident": "StiDataBand",
          "Name": "Dataroot",
          "ClientRectangle": "0,2,19.01,0.8",
          "Interaction": {
            "Ident": "StiBandInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueCount",
              "Guid": "a69edf60ad469bcdea40b988dc8b965c",
              "CanGrow": true,
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueCount}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Dataroot_organizationName",
              "Guid": "0cf651bc161c4b750a2c400eb51504bc",
              "CanGrow": true,
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.organizationName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueDetails",
              "Guid": "cb7ef2232411934c0452e533b14e6bdc",
              "CanGrow": true,
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueDetails}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Dataroot_totalUsers",
              "Guid": "121d711d5e13dc7da8c301d57a310c77",
              "CanGrow": true,
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalUsers}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          },
          "DataSourceName": "root"
        },
        "2": {
          "Ident": "StiFooterBand",
          "Name": "Footerroot",
          "ClientRectangle": "0,3.6,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueCount",
              "ClientRectangle": "0,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Footerroot_organizationName",
              "ClientRectangle": "4.8,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueDetails",
              "ClientRectangle": "9.6,0,4.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Footerroot_totalUsers",
              "ClientRectangle": "14.4,0,4.6,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        }
      },
      "PageWidth": 21.01,
      "PageHeight": 29.69,
      "Watermark": {
        "TextBrush": "solid:50,0,0,0"
      },
      "Margins": {
        "Left": 1,
        "Right": 1,
        "Top": 1,
        "Bottom": 1
      }
    }
  }
}', NULL, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-29T15:10:12.0830136' AS DateTime2))
INSERT [dbo].[ReportStructure_T] ([Id], [ReportId], [Configuration], [ProtoType], [CreationDate], [LastUpdatedDateTime]) VALUES (10, N'UsersActivation', N'{
  "ReportVersion": "2019.3.2",
  "ReportGuid": "815a87a8afa1148117b7ab403d05d2f4",
  "ReportName": "Report",
  "ReportAlias": "Report",
  "ReportFile": "Report.mrt",
  "ReportCreated": "/Date(1564296480000+0430)/",
  "ReportChanged": "/Date(1564296480000+0430)/",
  "EngineVersion": "EngineV2",
  "CalculationMode": "Interpretation",
  "ReportUnit": "Centimeters",
  "PreviewSettings": 268435455,
  "Dictionary": {
    "DataSources": {
      "0": {
        "Ident": "StiDataTableSource",
        "Name": "root",
        "Alias": "root",
        "Columns": {
          "0": {
            "Name": "fullName",
            "Index": -1,
            "NameInSource": "fullName",
            "Alias": "fullName",
            "Type": "System.String"
          },
          "1": {
            "Name": "totalIssueDetails",
            "Index": -1,
            "NameInSource": "totalIssueDetails",
            "Alias": "totalIssueDetails",
            "Type": "System.Decimal"
          },
          "2": {
            "Name": "title",
            "Index": -1,
            "NameInSource": "title",
            "Alias": "title",
            "Type": "System.String"
          },
          "3": {
            "Name": "userName",
            "Index": -1,
            "NameInSource": "userName",
            "Alias": "userName",
            "Type": "System.String"
          },
          "4": {
            "Name": "likesCount",
            "Index": -1,
            "NameInSource": "likesCount",
            "Alias": "likesCount",
            "Type": "System.Decimal"
          },
          "5": {
            "Name": "creationTime",
            "Index": -1,
            "NameInSource": "creationTime",
            "Alias": "creationTime",
            "Type": "System.String"
          },
          "6": {
            "Name": "issueType",
            "Index": -1,
            "NameInSource": "issueType",
            "Alias": "issueType",
            "Type": "System.Decimal"
          }
        },
        "NameInSource": "SimpleDataSet.root"
      }
    }
  },
  "Pages": {
    "0": {
      "Ident": "StiPage",
      "Name": "Page1",
      "Guid": "41c22bda81cfc365f887207215f68280",
      "Interaction": {
        "Ident": "StiInteraction"
      },
      "Border": ";;2;;;;;solid:Black",
      "Brush": "solid:Transparent",
      "Components": {
        "0": {
          "Ident": "StiHeaderBand",
          "Name": "Headerroot",
          "ClientRectangle": "0,0.4,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Headerroot_fullName",
              "Guid": "e9cce3be90626a410da73f9a35bbb040",
              "ClientRectangle": "0,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "fullName"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Headerroot_totalIssueDetails",
              "Guid": "567a961960b816dbc9d1605fdf208744",
              "ClientRectangle": "2.8,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "totalIssueDetails"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Headerroot_title",
              "Guid": "429bd569b6a5a72122d43bb58bf0255e",
              "ClientRectangle": "5.6,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "title"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Headerroot_userName",
              "Guid": "51f188653322370e3526795dc90877a2",
              "ClientRectangle": "8.4,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "userName"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Headerroot_likesCount",
              "Guid": "7d98b037df3e775e8073b9bf4410547a",
              "ClientRectangle": "11.2,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "likesCount"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "5": {
              "Ident": "StiText",
              "Name": "Headerroot_creationTime",
              "Guid": "a9634f78d6c31797df974364bc8ab864",
              "ClientRectangle": "14,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "creationTime"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "6": {
              "Ident": "StiText",
              "Name": "Headerroot_issueType",
              "Guid": "c0cbbeade93359369aa4b5dfefe26c84",
              "ClientRectangle": "16.8,0,2.2,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "issueType"
              },
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        },
        "1": {
          "Ident": "StiDataBand",
          "Name": "Dataroot",
          "ClientRectangle": "0,2,19.01,0.8",
          "Interaction": {
            "Ident": "StiBandInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Dataroot_fullName",
              "Guid": "e83848659cac333bc8ebefdd8146aa5b",
              "CanGrow": true,
              "ClientRectangle": "0,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.fullName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Dataroot_totalIssueDetails",
              "Guid": "ce2b86addc0e86e89755850d4df1c88a",
              "CanGrow": true,
              "ClientRectangle": "2.8,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.totalIssueDetails}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Dataroot_title",
              "Guid": "77d021855737bf6077c732ad2bbc6432",
              "CanGrow": true,
              "ClientRectangle": "5.6,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.title}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Dataroot_userName",
              "Guid": "5642a908c047de37ef55efd88ee29046",
              "CanGrow": true,
              "ClientRectangle": "8.4,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.userName}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Dataroot_likesCount",
              "Guid": "87a40365c95e55431885b0fcb8471958",
              "CanGrow": true,
              "ClientRectangle": "11.2,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.likesCount}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "5": {
              "Ident": "StiText",
              "Name": "Dataroot_creationTime",
              "Guid": "909ab03f97cad97cf029fe4eabfe235d",
              "CanGrow": true,
              "ClientRectangle": "14,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.creationTime}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "6": {
              "Ident": "StiText",
              "Name": "Dataroot_issueType",
              "Guid": "5c4aadba0b9b8aebedc68b2534dea752",
              "CanGrow": true,
              "ClientRectangle": "16.8,0,2.2,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "Text": {
                "Value": "{root.issueType}"
              },
              "VertAlignment": "Center",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          },
          "DataSourceName": "root"
        },
        "2": {
          "Ident": "StiFooterBand",
          "Name": "Footerroot",
          "ClientRectangle": "0,3.6,19.01,0.8",
          "Interaction": {
            "Ident": "StiInteraction"
          },
          "Border": ";;;;;;;solid:Black",
          "Brush": "solid:Transparent",
          "Components": {
            "0": {
              "Ident": "StiText",
              "Name": "Footerroot_fullName",
              "ClientRectangle": "0,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "1": {
              "Ident": "StiText",
              "Name": "Footerroot_totalIssueDetails",
              "ClientRectangle": "2.8,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "2": {
              "Ident": "StiText",
              "Name": "Footerroot_title",
              "ClientRectangle": "5.6,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "3": {
              "Ident": "StiText",
              "Name": "Footerroot_userName",
              "ClientRectangle": "8.4,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "4": {
              "Ident": "StiText",
              "Name": "Footerroot_likesCount",
              "ClientRectangle": "11.2,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "5": {
              "Ident": "StiText",
              "Name": "Footerroot_creationTime",
              "ClientRectangle": "14,0,2.8,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            },
            "6": {
              "Ident": "StiText",
              "Name": "Footerroot_issueType",
              "ClientRectangle": "16.8,0,2.2,0.8",
              "Interaction": {
                "Ident": "StiInteraction"
              },
              "HorAlignment": "Right",
              "VertAlignment": "Center",
              "Font": ";10;Bold;",
              "Border": ";;;;;;;solid:Black",
              "Brush": "solid:Transparent",
              "TextBrush": "solid:Black",
              "TextOptions": {
                "WordWrap": true
              }
            }
          }
        }
      },
      "PageWidth": 21.01,
      "PageHeight": 29.69,
      "Watermark": {
        "TextBrush": "solid:50,0,0,0"
      },
      "Margins": {
        "Left": 1,
        "Right": 1,
        "Top": 1,
        "Bottom": 1
      }
    }
  }
}', NULL, CAST(N'2018-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-29T14:55:12.4920128' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ReportStructure_T] OFF
