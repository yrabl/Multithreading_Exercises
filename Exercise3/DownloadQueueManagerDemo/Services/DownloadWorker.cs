using DownloadQueueManagerDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadQueueManagerDemo.Services;
public class DownloadWorker
{
    private readonly FileDownload _fileDownload;

    private readonly ApplicationStateManager _stateManager;

    public DownloadWorker(FileDownload fileDownload, ApplicationStateManager stateManager)
    {
        _fileDownload = fileDownload;
        _stateManager = stateManager;
    }

    public void Run()
    {
        int steps = 5;
        int stepDuration = _fileDownload.DownloadTime / steps;
        int currentStep = 0;
        if (_fileDownload.FileDownloadStatus == FileDownloadStatus.NotStarted)
        {
            _fileDownload.FileDownloadStatus = FileDownloadStatus.InProgress;
        }
        while (currentStep < steps)
        {
            if (_stateManager.ApplicationState == ApplicationState.Cancelled || _stateManager.ApplicationState == ApplicationState.Stopped)
            {
                _fileDownload.FileDownloadStatus = FileDownloadStatus.Cancelled;
                return;
            }
            else if (_stateManager.ApplicationState == ApplicationState.Paused)
            {
                _fileDownload.FileDownloadStatus = FileDownloadStatus.Paused;
                while (_stateManager.ApplicationState == ApplicationState.Paused)
                {
                    Thread.Sleep(100);
                }
            }
            else if (_stateManager.ApplicationState == ApplicationState.Downloading)
            {
                _fileDownload.FileDownloadStatus = FileDownloadStatus.InProgress;
                Thread.Sleep(stepDuration);
                currentStep++;
                _fileDownload.ElapsedTime += stepDuration;
                _fileDownload.DownloadProgress = currentStep * 20;
            }
        }
        _fileDownload.FileDownloadStatus = FileDownloadStatus.Completed;
    }
}
