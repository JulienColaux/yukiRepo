import { TestBed } from '@angular/core/testing';

import { CheckReportService } from './check-report.service';

describe('CheckReportService', () => {
  let service: CheckReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CheckReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
