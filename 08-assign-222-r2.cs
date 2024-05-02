#include "lib/helpers.cs"

#AddResults(_222-r2,
  #Persons(And((PsychSheetPosition(_222) > 2), (PsychSheetPosition(_222) < 25))))

Define("SubsequentRound", _222-r2)

#include "lib/basic-assign-subsequent.cs"
