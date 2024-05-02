#include "lib/helpers.cs"

#AddResults(_333oh-r2,
  #Persons(And((PsychSheetPosition(_333oh) > 2), (PsychSheetPosition(_333oh) < 23))))

Define("SubsequentRound", _333oh-r2)

#include "lib/basic-assign-subsequent.cs"
