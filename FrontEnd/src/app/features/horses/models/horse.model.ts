export type HorseType = 'racehorse' | 'stallion';

export type HorseStatus = 'enabled' | 'disabled' | 'all';

// Contrato del backend (api/horses). Todas las respuestas vienen envueltas en Result.
export interface ApiError {
  code: string;
  description: string;
}

export interface ApiResult<T = void> {
  value?: T;
  error: ApiError | null;
  isSuccess: boolean;
  isFailure: boolean;
}

export interface HorseDto {
  id: string;
  name: string;
  birthday: string;
  status: boolean;
  type: HorseType;
}

export interface CreateHorseRequest {
  name: string;
  birthday: string;
  type: HorseType;
}

export interface UpdateHorseRequest {
  name: string;
}
