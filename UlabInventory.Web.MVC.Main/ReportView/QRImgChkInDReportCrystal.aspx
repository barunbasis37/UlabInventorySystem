﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QRImgChkInDReportCrystal.aspx.cs" Inherits="UlabInventory.Web.MVC.Main.ReportView.QRImgChkInDReportCrystal" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Height="400" Width="600"/>
</form>
</body>
</html>
