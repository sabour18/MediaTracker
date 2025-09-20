import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WatchedTitlesComponent } from './watched-titles.component';

describe('WatchedTitlesComponent', () => {
  let component: WatchedTitlesComponent;
  let fixture: ComponentFixture<WatchedTitlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WatchedTitlesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WatchedTitlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
