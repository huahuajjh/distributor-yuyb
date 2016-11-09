CREATE VIEW v_sch_refs
AS
SELECT 
	r.Id AS RId,
	r.Name AS RName,
	r.Tel AS Tel,
	s.Id AS SId,
	s.Name AS SName,
	s.ShortName AS SShortName,
	s.AreaId AS AreaId
	FROM [References] r LEFT JOIN [School] s
		ON r.SchoolId = s.Id