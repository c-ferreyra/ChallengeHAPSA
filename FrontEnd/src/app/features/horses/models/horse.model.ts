export type HorseStatus = 'enabled' | 'disabled';

export type HorseType = 'racehorse' | 'stallion';

export interface Horse {
  id: number;
  name: string;
  birthDate: string;
  status: HorseStatus;
  type: HorseType;
}

export interface HorseSearchFilters {
  name: string | null;
  status: HorseStatus | null;
  type: HorseType | null;
}
