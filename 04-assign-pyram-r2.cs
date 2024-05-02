#include "lib/helpers.cs"

#AddResults(_pyram-r2,
  #Persons(And((PsychSheetPosition(_pyram) > 3), (PsychSheetPosition(_pyram) < 28))))

Define("SubsequentRound", _pyram-r2)

#include "lib/basic-assign-subsequent.cs"
