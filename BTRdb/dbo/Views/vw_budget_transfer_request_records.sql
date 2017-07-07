CREATE VIEW [dbo].[vw_budget_transfer_request_records] AS
SELECT btr.[btr_key]
      ,btr.[btr_guid]
	  ,btr.[title]
      ,btr.[budget_type_key]
	  ,xbt.[budget_type]
      ,btr.[life_cycle_key]
	  ,xlc.[life_cycle]
	  ,xit.[internal_state]
      ,btr.[internal_state_key]
      ,u.[uni_code] as request_uni_code
	  ,btr.[requestor_uni_key]
      ,btr.[total_amount]
      ,btr.[explanation]
      ,btr.[priority_flag]
	  ,btr.[transfer_type_key]
	  ,xtt.[transfer_type]
	  ,btr.[created]
	  ,btr.[created_by]
	  ,uc.[uni_email] as created_by_name
	  ,btr.[modified]
	  ,btr.[modified_by]
	  ,um.[uni_email] as modified_by_name
	  
  FROM [dbo].[budget_transfer_request] btr 
  inner join [dbo].[xref_budget_type] xbt on (btr.budget_type_key = xbt.budget_type_key)
  inner join [dbo].[xref_internal_state] xit on (btr.internal_state_key = xit.internal_state_key)
  inner join [dbo].[xref_life_cycle] xlc on (btr.life_cycle_key = xlc.life_cycle_key)
  left join [dbo].[users] u on (btr.requestor_uni_key = u.uni_key)
  inner join [dbo].[xref_transfer_type] xtt on (btr.transfer_type_key = xtt.transfer_type_key)
  left join [dbo].[users] uc on (btr.created_by = uc.uni_key)
  left join [dbo].[users] um on (btr.modified_by = um.uni_key)
  


