#include "lib/helpers.cs"

#AddResults(_pyram-r2,
  #Persons(And((PsychSheetPosition(_pyram) > 3), (PsychSheetPosition(_pyram) < 28))))
Define("QualifiedPyram", Persons(CompetingInRound(_pyram-r2)))

Length(QualifiedPyram())

# Clear staff assignments for qualified people to pyraminx 2nd round
ClearAssignments(QualifiedPyram(), true, false, _pyram-r2)

AssignGroups(_pyram-r2,
    EveryoneAssignmentSet())
