using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;
using log4net.Layout;
using log4net.Appender;


namespace IMGprocessing
{
    class ClsLog
    {
        public static ClsLog LOG = new ClsLog(ClsDefine.PATH_LOG);
        log4net.ILog log;
        log4net.Repository.Hierarchy.Hierarchy m_Hierarchy;

        #region KHAI BAO BIEN
        DateTime m_today_log;

        public string m_str_path_root;
        public string m_str_path_log;

        public bool m_b_save_log = true; 

        // số lượng tệp sao lưu mỗi ngày và số ngày max để lưu ảnh
        public int m_i_maxSize_size_backups = 0;
        public int m_i_maxSize_date_backups = 30; // Số ngày lưu log

        string m_str_maximum_file_size = "1000MB";
        #endregion

        #region constructor
        // HÀM KHỞI TẠO SETTING ĐƯỜNG DẪN
        public ClsLog(string _path_Save_Log)
        {
            //m_str_path_root = ClsDefine.PATH_ROOT_LOG;// path root
            m_str_path_log = _path_Save_Log;        // file Log

            // ? chưa biết
            log = log4net.LogManager.GetLogger("LOG");

            // ? chưa biết
            //logger가 담긴 Repository 계층구조 가져옴.
            m_Hierarchy = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
            m_Hierarchy.Configured = true;  //이 옵션을 켜줘야 동적생성 가능

            //Setting config
            AddApender(log, "%date{yyyy:MM:dd},%date{HH:mm:ss}, %message%newline");

            // sắp xếp lại folder lưu log file
            CleanLogFolder();

            // Lưu ngày bắt đầu mở chương trình
            m_today_log = DateTime.Now;
        }
        #endregion

        // installs file config log4net
        void AddApender(log4net.ILog log, string strPattern)
        {
            log4net.Repository.Hierarchy.Logger logger = (log4net.Repository.Hierarchy.Logger)log.Logger;
            log4net.Appender.RollingFileAppender appender = new log4net.Appender.RollingFileAppender();

            //appender installs
            appender.File = Path.Combine(m_str_path_log, "Log_.txt");                 // Tên của file log đầy đủ
            appender.PreserveLogFileNameExtension = true;                             //파일 확장자를 유지할건지 아닌지 결정. true로 해야 위에서 만든 확장자 그대로.
            appender.StaticLogFileName = false;                                       //Tên tệp có được cố định hay không, false sẽ được định dạng thành ngày tháng, true tên sẽ cố định

            appender.Encoding = System.Text.Encoding.UTF8;                         // sử dụng unicode
            appender.AppendToFile = true;                                             // True: ghi ra file

            appender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();  //Cách lấy IO handle khi ghi vào tệp ở trên.

            appender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Composite;

            //파일 사이즈로 Rolling 하는 부분. 
            appender.MaxSizeRollBackups = m_i_maxSize_size_backups; // Số lượng tệp được backup mỗi ngày nếu vượt quá, các tệp cũ sẽ bị xóa
            appender.MaximumFileSize = m_str_maximum_file_size;  // sao lưu với kích thước tệp, nếu lớn hơn 1 file mới sẽ được tạo.

            //날짜 지나면 파일 새로 만든다. Rolling은 안된다
            appender.DatePattern = "yyyyMMdd"; // 날짜가 지나간 경우 이전 로그에 붙을 이름 구성 

            //Log기록하는 패턴.
            appender.Layout = new log4net.Layout.PatternLayout(strPattern);

            //Appender 활성화 및 로그에 붙이기
            appender.ActivateOptions();

            logger.AddAppender(appender);
            logger.Hierarchy = m_Hierarchy;
            logger.Level = logger.Hierarchy.LevelMap["ALL"]; // Level lưu log, lưu tất cả các log
        }

        // sắp sếp lại folder lưu log
        void CleanLogFolder()
        {
            // Tạo folder lưu log
            if (!Directory.Exists(m_str_path_log)) Directory.CreateDirectory(m_str_path_log);
            //Xóa các file k có extension là .txt trong file log
            string[] strLogFiles = Directory.GetFiles(m_str_path_log);
            foreach (string strLogFile in strLogFiles)
            {
                string strLogFileExtension = Path.GetExtension(strLogFile);
                if (strLogFileExtension.ToLower() != ".txt")
                    File.Delete(strLogFile);
            }
        }

        //Xóa thư mục log theo số tệp tối đa
        public void RollOverDate(ILog log, bool bInitFlag = false)
        {
            try
            {
                // Kiểm tra ngày. return nếu ngày không thay đổi thì return
                // Nếu bInitFlag là true, không kiểm tra
                if ((DateTime.Now.Subtract(m_today_log).TotalDays < 1) && !bInitFlag) return;

                if (!Directory.Exists(m_str_path_log)) // kiểm tra thư mục có tồn tại k? 
                    Directory.CreateDirectory(m_str_path_log);

                string[] strLogFiles = Directory.GetFiles(m_str_path_log); // lấy file trong thư mục log
                int iCountOfFilesInDir = strLogFiles.GetLength(0);
                if (iCountOfFilesInDir <= 1) return; //return nếu không có file hoặc chỉ có 1 file

                // Kiểm tra số ngày đã vượt quá giới hạn lưu hay chưa?
                int iOverCount = iCountOfFilesInDir - m_i_maxSize_date_backups;
                if (iOverCount > 0)
                {
                    // sắp xếp file theo tên
                    for (int i = 0; i < iCountOfFilesInDir; i++)
                    {
                        for (int j = iCountOfFilesInDir - 1; j > i; j--)
                        {
                            if (strLogFiles[j - 1].CompareTo(strLogFiles[j]) > 0)
                            {
                                string strTemp = strLogFiles[j - 1];
                                strLogFiles[j - 1] = strLogFiles[j];
                                strLogFiles[j] = strTemp;
                            }
                        }
                    }
                    //xóa file cũ nhất
                    for (int i = 0; i < iOverCount; i++)
                    {
                        if (File.Exists(strLogFiles[i]))
                        {
                            System.IO.File.Delete(strLogFiles[i]);
                        }
                    }
                }
                // update ngày hiện tại
                if (!bInitFlag)
                    m_today_log = DateTime.Now;
            }
            catch (Exception ex)
            {
                if (!m_b_save_log) return;
                log.Debug("ERROR, RollOverDate error: " + ex.ToString());
            }
        }

        // Các phương thức để lưu log
        #region METHOD SAVE LOG
        public void Sequence(string message)
        {
            if (!m_b_save_log) return;
            RollOverDate(log);
            log.Debug("SEQUENCE, " + message);
        }

        public void Error(string message)
        {
            if (!m_b_save_log) return;
            RollOverDate(log);
            log.Debug("ERROR, " + message);
        }

        public void Debug(string message)
        {
            if (!m_b_save_log) return;
            RollOverDate(log);
            log.Debug("DEBUG, " + message);
        }

        public void Socket(string message)
        {
            if (!m_b_save_log) return;
            RollOverDate(log);
            log.Debug("SOCKET, " + message);
        }

        public void Data(string message)
        {
            if (!m_b_save_log) return;
            RollOverDate(log);
            log.Debug("DATA, " + message);
        }

        public void DataAI(string _path, string message)
        {
            try
            {
                string pathLog = _path + "\\LogAI.txt";
                string[] text = new string[1];
                text[0] = DateTime.Now.ToLocalTime().ToString("HH:mm:ss") + ", " + message;
                File.AppendAllLines(pathLog, text);
            }
            catch (Exception ex)
            {
                Socket(string.Format("Path:{0} Write DataAI error: {1}", _path, ex.ToString()));
            }
        }

        public void DataWarning(string _path, string message)
        {
            try
            {
                string pathLog = _path + "\\LogWarning.txt";
                string[] text = new string[1];
                text[0] = DateTime.Now.ToLocalTime().ToString("HH:mm:ss") + ", " + message;
                File.AppendAllLines(pathLog, text);
            }
            catch (Exception ex)
            {
                Socket(string.Format("Path:{0} Write DataWarning error: {1}", _path, ex.ToString()));
            }
        }


        #endregion
    }
}
