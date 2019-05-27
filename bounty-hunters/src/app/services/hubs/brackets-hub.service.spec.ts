import { TestBed, inject } from '@angular/core/testing';

import { BracketsHubService } from './brackets-hub.service';

describe('BracketsHubService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BracketsHubService]
    });
  });

  it('should be created', inject([BracketsHubService], (service: BracketsHubService) => {
    expect(service).toBeTruthy();
  }));
});
