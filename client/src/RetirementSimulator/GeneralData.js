import "./style/PensionType.css"
import Sequence from "./Sequence";
import PreviousNext from "./PreviousNext";
import * as React from 'react';
import { styled } from '@mui/material/styles';
import ArrowForwardIosSharpIcon from '@mui/icons-material/ArrowForwardIosSharp';
import MuiAccordion from '@mui/material/Accordion';
import MuiAccordionSummary from '@mui/material/AccordionSummary';
import MuiAccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import PersonalData from "./generalData/PersonalData";
import BudgetPensin from "./UserSee/BudgetPension";
import AccrualPension from "./generalData/AccrualPension";


const Accordion = styled((props) => (
    <MuiAccordion disableGutters elevation={0} square {...props} />
))(({ theme }) => ({
    border: `1px solid ${theme.palette.divider}`,
    '&:not(:last-child)': {
        borderBottom: 0,
    },
    '&:before': {
        display: 'none',
    },
}));

const AccordionSummary = styled((props) => (
    <MuiAccordionSummary
        expandIcon={<ArrowForwardIosSharpIcon sx={{ fontSize: '0.9rem' }} />}
        {...props}
    />
))(({ theme }) => ({
    backgroundColor:
        theme.palette.mode === 'dark'
            ? 'rgba(255, 255, 255, .05)'
            : 'rgba(0, 0, 0, .03)',
    flexDirection: 'row-reverse',
    '& .MuiAccordionSummary-expandIconWrapper.Mui-expanded': {
        transform: 'rotate(90deg)',
    },
    '& .MuiAccordionSummary-content': {
        marginLeft: theme.spacing(1),
    },
}));

const AccordionDetails = styled(MuiAccordionDetails)(({ theme }) => ({
    padding: theme.spacing(2),
    borderTop: '1px solid rgba(0, 0, 0, .125)',
}));

function GeneralData() {

    const [expanded, setExpanded] = React.useState('panel1');

    const handleChange = (panel) => (event, newExpanded) => {
        setExpanded(newExpanded ? panel : false);
    };


    return (
        <>
            <Sequence page="2"></Sequence>
            <div class="card bg-light mb-3">
                <div class="card-header">נתונים כלליים</div>
                <div class="card-body">


                    <Accordion expanded={expanded === 'panel1'} onChange={handleChange('panel1')}>
                        <AccordionSummary aria-controls="panel1d-content" id="panel1d-header">
                            <Typography>נתונים אישיים</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            {/* <Typography> */}
                               <PersonalData></PersonalData>
                            {/* </Typography> */}
                        </AccordionDetails>
                    </Accordion>
                    <Accordion expanded={expanded === 'panel2'} onChange={handleChange('panel2')}>
                        <AccordionSummary aria-controls="panel2d-content" id="panel2d-header">
                            <Typography>פנסיה תקציבית </Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            {/* <Typography> */}
                               <BudgetPensin></BudgetPensin>
                            {/* </Typography> */}
                        </AccordionDetails>
                    </Accordion>
                    <Accordion expanded={expanded === 'panel3'} onChange={handleChange('panel3')}>
                        <AccordionSummary aria-controls="panel3d-content" id="panel3d-header">
                            <Typography>פנסיה צוברת</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            {/* <Typography> */}
                               <AccrualPension></AccrualPension>
                            {/* </Typography> */}
                        </AccordionDetails>
                    </Accordion>


                </div>
            </div>


            <PreviousNext next="Vacation" previous="PensionType"></PreviousNext>
        </>
    )
}
export default GeneralData;