import { HttpInterceptorFn } from '@angular/common/http';
import { environment } from './environment';

export const ApiInterceptor: HttpInterceptorFn = (req, next) => {
  const apiReq = req.clone({ url: `${environment.apiBaseUrl}/${req.url}` });
  return next(apiReq);
};
