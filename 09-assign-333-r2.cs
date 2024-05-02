#include "lib/helpers.cs"
#include "lib/r2-helpers.cs"

#AddResults(_333-r2,
  #Persons((PsychSheetPosition(_333) < 73)))

AssignGroups(_333-r2,
  Concat(
    TopCompetitors(_333, 10, 3),
    EveryoneAssignmentSet()
    ))
