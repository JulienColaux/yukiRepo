
import { Component, OnInit } from '@angular/core';
import { InfoReport } from '../../../core/models/info-report';
import { CheckReportService } from '../../../core/services/check-report.service';

@Component({
    selector: 'app-check-report',
    templateUrl: './check-report.component.html',
    styleUrl: './check-report.component.scss'
})
export class CheckReportComponent implements OnInit {

    listReport: InfoReport[] = [];
    filteredReport: InfoReport[] = [];

    categorie: string = '';
    options: string[] = ['Report Name', 'Report Year', 'Intern Name'];

    userInput: string = '';
    submittedValue: string = '';

    constructor(private checkReportService: CheckReportService) { }

    // Initialize the component by calling the service to fetch reports
    ngOnInit(): void {
        this.checkReportService.getAllInfosReport().subscribe(
            (data) => {
                this.listReport = data;
            },
            (error) => {
                console.error('Error while fetching data', error);
            }
        );
        // Initially, the filtered list displays all reports
        this.filteredReport = this.listReport;
    }

    // Filter reports by name. If no name is provided, reset the filtered list to include all reports
    filterReportByName(name: string): void {
        if (!name) {
            // No name provided, show all reports
            this.filteredReport = [...this.listReport];
            console.log("No name provided...");
        } else {
            // Filter reports whose names include the given string (case-insensitive)
            this.filteredReport = this.listReport.filter(report =>
                report.name.toLowerCase().includes(name.toLowerCase())
            );
        }
    }

    // Filter reports by year. If no year is provided, handle it (e.g., show a message). Otherwise, filter by the given year
    filterReportByYear(year: string): void {
        if (!year) {
            console.log("Year not provided...");
        } else {
            this.filteredReport = this.listReport.filter(report =>
                report.year === parseInt(year)
            );
        }
    }

    // Capture the user's input and assign it to a property for use in other functions
    submitValue(): void {
        this.submittedValue = this.userInput;
    }

    // Filter reports based on the selected category (name or year) using the user's input
    filterReports(input: string): void {
        this.submitValue(); // Capture the current input
        if (this.categorie === 'Report Name') {
            // Filter by name if the category is "Report Name"
            this.filterReportByName(input);
        }
        if (this.categorie === 'Report Year') {
            // Filter by year if the category is "Report Year"
            this.filterReportByYear(input);
        }
    }
}

