public static void CreaPDFByReporteTelerik(byte[] reporte_trdx, string fullpatharchivopdf, List<Telerik.Reporting.Parameter> parametrosreporte)
{
	System.Xml.XmlReaderSettings xmlsettings = new System.Xml.XmlReaderSettings();
	xmlsettings.IgnoreWhitespace = true;
	using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(new MemoryStream(reporte_trdx), xmlsettings))
	{
		Telerik.Reporting.Report rpt = (Telerik.Reporting.Report)(new Telerik.Reporting.XmlSerialization.ReportXmlSerializer()).Deserialize(xmlReader);

		Telerik.Reporting.Processing.ReportProcessor rptprocesador = new Telerik.Reporting.Processing.ReportProcessor();
		System.Collections.Hashtable dispositivoInfo = new System.Collections.Hashtable();
		Telerik.Reporting.InstanceReportSource rptfuente = new Telerik.Reporting.InstanceReportSource();
		rptfuente.ReportDocument = rpt;
		if (parametrosreporte != null)
		{
			foreach (Telerik.Reporting.Parameter param in parametrosreporte)
			{
				rptfuente.Parameters.Add(param);
			}
		}
		Telerik.Reporting.Processing.RenderingResult rptresultado = rptprocesador.RenderReport("PDF", rptfuente, dispositivoInfo);
		using (System.IO.FileStream fs = new System.IO.FileStream(fullpatharchivopdf, System.IO.FileMode.Create))
		{
			fs.Write(rptresultado.DocumentBytes, 0, rptresultado.DocumentBytes.Length);
		}
	}
}
