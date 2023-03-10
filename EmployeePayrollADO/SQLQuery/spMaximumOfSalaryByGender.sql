Create or Alter procedure spMaximumOfSalaryByGender
(
	@Gender varchar(1)
)
As 
Begin try
Select Max(Salary) From Employee 
Where Gender=@Gender Group by Gender
End Try
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH;