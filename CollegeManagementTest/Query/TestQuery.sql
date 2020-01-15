--this test query serves as the base for the query of each course students' average grade
--it should definitely be a stored procedure, but since the database is local, i've decided
--to do it all in linq

select distinct s.Name, AVG(g.Value) from Student s
inner join Grade g
on g.StudentId = s.Id
inner join Subject sbj
on sbj.Id = g.SubjectId
inner join CourseSubjects cs
on cs.SubjectId = sbj.Id
where cs.CourseId = 1
and s.Id Not in (
	--select all students that are not part of this course
	select distinct s.id from Student s
	inner join Grade g
	on g.StudentId = s.Id
	inner join Subject sbj
	on sbj.Id = g.SubjectId
	inner join CourseSubjects cs
	on cs.SubjectId = sbj.Id
	where sbj.Id in (
		-- select all subjects that are not part of course
		select distinct sbj.Id from Subject sbj
		inner join CourseSubjects csbj
		on sbj.Id = csbj.SubjectId
		where sbj.Id NOT IN (select sbj.Id from Subject sbj
							inner join CourseSubjects csbj
							on sbj.Id = csbj.SubjectId where csbj.CourseId = 1)
	)
)
group by s.Name
