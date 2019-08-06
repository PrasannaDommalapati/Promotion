import { library } from '@fortawesome/fontawesome-svg-core'
import {
    faCheckCircle,
    faCircleNotch,
    faCloudDownloadAlt,
    faDotCircle,
    faEnvelope,
    faExclamationTriangle,
    faFile,
    faFileAlt,
    faFileCode,
    faFilePdf,
    faPaperPlane,
    faPrint,
    faScroll,
    faTasks,
    faTimesCircle,
    faWallet
} from '@fortawesome/free-solid-svg-icons';

library.add(
    faCheckCircle,
    faCircleNotch,
    faCloudDownloadAlt,
    faDotCircle,
    faEnvelope,
    faExclamationTriangle,
    faFile,
    faFileCode,
    faFilePdf,
    faFileAlt,
    faPaperPlane,
    faPrint,
    faScroll,
    faTasks,
    faTimesCircle,
    faWallet);

const Icons = {
    ActionDefault: 'dot-circle',
    ActionError: 'times-circle',
    Actions: 'tasks',
    ActionSuccess: 'check-circle',
    Busy: 'circle-notch',
    Download: 'cloud-download-alt',
    Error: 'exclamation-triangle',
    Envelope: 'envelope',
    File: 'file',
    FileAlt: 'file-alt',
    FileCode: 'file-code',
    FilePdf: 'file-pdf',
    FileJson:'scroll',
    Outputs: 'paper-plane',
    Print: 'print',
    Wallet:'wallet'

};

export default Icons;